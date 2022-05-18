using Microsoft.Azure.Cosmos.Table;

namespace UnsplashAPI.config
{
    public class TableStorageConfig
    {
        public static CloudTable GetTable()
        {
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=unsplashapi2022051813040;AccountKey=m7TM7Az56NKc/rfZbCjwMi3YlO1M7fYPjvqz57E000xGY6Pl7QezzDsQlg22pPWeS9PDWaE8kjn8+AStzWYmTA==;EndpointSuffix=core.windows.net";
            string tableName = "Image";
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            return tableClient.GetTableReference(tableName);
        }
    }
}
