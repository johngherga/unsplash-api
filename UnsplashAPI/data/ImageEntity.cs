using Microsoft.Azure.Cosmos.Table;

namespace UnsplashAPI.data
{
    public class ImageEntity : TableEntity
    {
        public ImageEntity()
        {

        }

        public ImageEntity(string imageId, string userId)
        {
            PartitionKey = imageId;
            RowKey = userId;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }
        public int TenDayDownloads { get; set; }
        public double PercentOfTotalDownloads { get; set; }
    }
}
