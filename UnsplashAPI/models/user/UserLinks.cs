using System.Text.Json.Serialization;

namespace UnsplashAPI.models.user
{
    public class UserLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; }
        [JsonPropertyName("html")]
        public string Html { get; set; }
        [JsonPropertyName("photos")]
        public string Photos { get; set; }
        [JsonPropertyName("likes")]
        public string Likes { get; set; }
        [JsonPropertyName("portfolio")]
        public string Portfolio { get; set; }
    }
}
