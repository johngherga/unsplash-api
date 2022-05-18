using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnsplashAPI.config;
using UnsplashAPI.data;

namespace UnsplashAPI.repository
{
    public class ImageRepository
    {
        static CloudTable table = TableStorageConfig.GetTable();
        public static async Task AddImage(ImageEntity imageEntity)
        {
            TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(imageEntity);

            TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
            ImageEntity insertedImageEntity = result.Result as ImageEntity;
            Console.WriteLine($"Added image : {insertedImageEntity.PartitionKey}");
        }

        public static async Task<ImageEntity> GetImage(string imageId, string userId)
        {
            TableOperation retrieveOperation = TableOperation.Retrieve<ImageEntity>(imageId, userId);
            TableResult result = await table.ExecuteAsync(retrieveOperation);
            ImageEntity imageEntity = result.Result as ImageEntity;

            if (imageEntity != null)
            {
                Console.WriteLine("Fetched \t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
                    imageEntity.PartitionKey, imageEntity.RowKey, imageEntity.Name, imageEntity.Width, imageEntity.Height, imageEntity.TenDayDownloads, imageEntity.PercentOfTotalDownloads);
                return imageEntity;
            } else
            {
                throw new ArgumentException("Invalid image id or user id");
            }
        }
    }
}
