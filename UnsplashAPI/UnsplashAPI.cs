using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UnsplashAPI.models.image;
using UnsplashAPI.models.image.response;

namespace UnsplashAPI
{
    public static class UnsplashAPI
    {
        private static readonly HttpClient client = new HttpClient();

        [FunctionName("GetImageDaily")]
        public static async Task GetImageDaily([TimerTrigger("0 30 9 * * *")] TimerInfo myTimer, ILogger logger)
        {
            logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

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

            ImageDTO imageDto = new ImageDTO
            {
                ImageId = imageResponse?.Id,
                Width = imageResponse.Width,
                Height = imageResponse.Height,
                UserId = imageResponse.User.Id,
                Name = imageResponse.User.Name,
                TenDayDownloads = imageStatResponse.Downloads.Historical.Change,
                PercentOfTotalDownloads = CalculatePercentage(imageStatResponse.Downloads.Historical.Change, imageResponse.Downloads)
            };

            logger.LogInformation($"IMAGE STATS ID: {imageStatResponse.Id}");
            logger.LogInformation($"IMAGE STATS DOWNLOADS: {imageStatResponse.Downloads.Historical.Change}");
            logger.LogInformation($"TOTAL DOWNLOADS: {imageResponse.Downloads}");
            logger.LogInformation($"TOTAL Width: {imageResponse.Width}");
            logger.LogInformation($"TOTAL Height: {imageResponse.Height}");

        }

        [FunctionName("GetRandomImage")]
        public static async Task<IActionResult> GetRandomImage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "image")] HttpRequest request,
            ILogger logger)
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

            ImageDTO imageDto = new ImageDTO
            {
                ImageId = imageResponse?.Id,
                Width = imageResponse.Width,
                Height = imageResponse.Height,
                UserId = imageResponse.User.Id,
                Name = imageResponse.User.Name,
                TenDayDownloads = imageStatResponse.Downloads.Historical.Change,
                PercentOfTotalDownloads = CalculatePercentage(imageStatResponse.Downloads.Historical.Change, imageResponse.Downloads)
            };

            logger.LogInformation($"IMAGE STATS ID: {imageStatResponse.Id}");
            logger.LogInformation($"IMAGE STATS DOWNLOADS: {imageStatResponse.Downloads.Historical.Change}");
            logger.LogInformation($"TOTAL DOWNLOADS: {imageResponse.Downloads}");
            logger.LogInformation($"TOTAL Width: {imageResponse.Width}");
            logger.LogInformation($"TOTAL Height: {imageResponse.Height}");

            return new OkObjectResult(imageDto);
        }


        public static async Task<ImageStatResponse> GetImageStatistics(string imageId, ILogger logger)
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

        static double CalculatePercentage(int num1, int num2)
        {
            return Math.Round(((double)num1 / (double)num2) * 100);
        }
    }
}
