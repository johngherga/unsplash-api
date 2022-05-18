using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UnsplashAPI.data;
using UnsplashAPI.models.dto;
using UnsplashAPI.models.image.response;
using UnsplashAPI.repository;

namespace UnsplashAPI.service
{
    public class ImageService
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<ImageDTO> GetImage(string imageId, string userId)
        {
            ImageEntity imageEntity = await ImageRepository.GetImage(imageId, userId);
            return MapEntityToDTO(imageEntity);
        }

        public static async Task<ImageDTO> SaveRandomImage(ILogger logger)
        {
            logger.LogInformation($"Getting image from unsplash API.");

            client.DefaultRequestHeaders.Add("Accept-Version", "v1");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", "L4y-Z6EELfXpBfQnwFbe19Us6eFVbf4EIHNAGBmBxBQ");

            HttpResponseMessage response = await client.GetAsync("https://api.unsplash.com/photos/random");

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            ImageResponse imageResponse = JsonConvert.DeserializeObject<ImageResponse>(responseBody, settings);
            ImageStatResponse imageStatResponse = GetImageStatistics(imageResponse?.Id, logger).Result;

            ImageEntity imageEntity = new ImageEntity(imageResponse.Id, imageResponse.User.Id)
            {
                Width = imageResponse.Width,
                Height = imageResponse.Height,
                Name = imageResponse.User.Name,
                TenDayDownloads = imageStatResponse.Downloads.Historical.Change,
                PercentOfTotalDownloads = CalculatePercentage(imageStatResponse.Downloads.Historical.Change, imageResponse.Downloads)
            };

            await ImageRepository.AddImage(imageEntity);

            logger.LogInformation($"ImageId: {imageResponse.Id}");
            logger.LogInformation($"UserId: {imageResponse.User.Id}");
            logger.LogInformation($"Name: {imageResponse.User.Name}");
            logger.LogInformation($"Width: {imageResponse.Width}");
            logger.LogInformation($"Height: {imageResponse.Height}");
            logger.LogInformation($"TenDayDownloads: {imageStatResponse.Downloads.Historical.Change}");
            logger.LogInformation($"PercentOfTotalDownloads: {CalculatePercentage(imageStatResponse.Downloads.Historical.Change, imageResponse.Downloads)}");

            return MapEntityToDTO(imageEntity);
        }

        private static async Task<ImageStatResponse> GetImageStatistics(string imageId, ILogger logger)
        {
            logger.LogInformation($"Getting image statistics with id: {imageId}");

            client.DefaultRequestHeaders.Add("Accept-Version", "v1");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", "L4y-Z6EELfXpBfQnwFbe19Us6eFVbf4EIHNAGBmBxBQ");

            HttpResponseMessage response = await client.GetAsync($"https://api.unsplash.com/photos/{imageId}/statistics/?quantity=10");

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            ImageStatResponse imageStatResponse = JsonConvert.DeserializeObject<ImageStatResponse>(responseBody);

            return imageStatResponse;
        }

        private static double CalculatePercentage(int num1, int num2)
        {
            return Math.Round(((double)num1 / (double)num2) * 100);
        }

        private static ImageDTO MapEntityToDTO(ImageEntity entity)
        {
            ImageDTO imageDTO = new ImageDTO
            {
                ImageId = entity.PartitionKey,
                UserId = entity.RowKey,
                Name = entity.Name,
                Width = entity.Width,
                Height = entity.Height,
                TenDayDownloads = entity.TenDayDownloads,
                PercentOfTotalDownloads = entity.PercentOfTotalDownloads
            };

            return imageDTO;
        }
    }
}
