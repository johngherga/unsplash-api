using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace UnsplashAPI
{
    public static class UnsplashAPI
    {
        private static readonly HttpClient client = new HttpClient();

        [FunctionName("GetImageDaily")]
        public static void GetImageDaily([TimerTrigger("0012**?")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }

        [FunctionName("GetRandomImage")]
        public static async Task<IActionResult> GetRandomImage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "image")] HttpRequest request,
            ILogger logger)
        {
            logger.LogInformation($"Getting image from unsplash API.");

            client.DefaultRequestHeaders.Add("Accept-Version", "v1");
            client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Client-ID", "6P1j7UZBWSnsLt5Fwg6kq6m_UCRbqee_rc4PLcjxHZg");

            HttpResponseMessage response = await client.GetAsync("https://api.unsplash.com/photos/random");

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            logger.LogInformation($"Image id: {responseBody}");

            return new OkObjectResult(responseBody);
        }

        [FunctionName("GetImageStat")]
        public static async Task<IActionResult> GetImageStat(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "image/stat")] HttpRequest request,
    ILogger logger)
        {
            logger.LogInformation($"Getting image statistics from unsplash API.");

            client.DefaultRequestHeaders.Add("Accept-Version", "v1");
            client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Client-ID", "6P1j7UZBWSnsLt5Fwg6kq6m_UCRbqee_rc4PLcjxHZg");

            HttpResponseMessage response = await client.GetAsync("https://api.unsplash.com/photos/:id/statistics");

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();


            return new OkObjectResult(responseBody);
        }
    }
}
