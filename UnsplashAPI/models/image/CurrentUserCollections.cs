using System.Text.Json.Serialization;

namespace UnsplashAPI.models.image
{
    public class CurrentUserCollections
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("published_at")]
        public string PublishedAt { get; set; }
        [JsonPropertyName("last_collected_at")]
        public string LastCollectedAt { get; set; }
        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }
        [JsonPropertyName("cover_photo")]
        public bool CoverPhoto { get; set; }
        [JsonPropertyName("user")]
        public bool User { get; set; }
    }
}
