using System.Text.Json.Serialization;

namespace UnsplashAPI.models.image.response
{
    public class Downloads
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("historical")]
        public Historical Historical { get; set; }
    }
}
