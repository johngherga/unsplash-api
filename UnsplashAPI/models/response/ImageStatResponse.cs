using System.Text.Json.Serialization;

namespace UnsplashAPI.models.image.response
{
    public class ImageStatResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("downloads")]
        public Downloads Downloads { get; set; }
    }
}
