using System.Text.Json.Serialization;
using UnsplashAPI.models.user;

namespace UnsplashAPI.models
{
    public class User
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("portfolio_url")]
        public string PortfolioUrl { get; set; }
        [JsonPropertyName("bio")]
        public string Bio { get; set; }
        [JsonPropertyName("location")]
        public string Location { get; set; }
        [JsonPropertyName("total_likes")]
        public int TotalLikes { get; set; }
        [JsonPropertyName("total_photos")]
        public int TotalPhotos { get; set; }
        [JsonPropertyName("total_collections")]
        public int TotalCollections { get; set; }
        [JsonPropertyName("instagram_username")]
        public string InstagramUsername { get; set; }
        [JsonPropertyName("twitter_username")]
        public string TwitterUsername { get; set; }
        [JsonPropertyName("links")]
        public UserLinks Links { get; set; }
    }
}
