using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using UnsplashAPI.models.dto;
using UnsplashAPI.service;

namespace UnsplashAPI.rest
{
    public class ImageController
    {
        // Save a random image from unsplash api once every day at 09.30
        [FunctionName("SaveImageDaily")]
        public static async Task SaveImageDaily([TimerTrigger("0 30 9 * * *")] TimerInfo myTimer, ILogger logger)
        {
            logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            await ImageService.SaveRandomImage(logger);
        }

        // Manually save random image from unsplash api
        [FunctionName("SaveImage")]
        public static async Task SaveImage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "image/save")] HttpRequest request,
            ILogger logger)
        {
            await ImageService.SaveRandomImage(logger);
        }

        // Get image from Azure Table Storage with image id and user id
        [FunctionName("GetImage")]
        public static async Task<ImageDTO> GetImage(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "image/{imageId}/{userId}")] HttpRequest request, string imageId, string userId,
            ILogger logger)
        {
            return await ImageService.GetImage(imageId, userId);
        }
    }
}
