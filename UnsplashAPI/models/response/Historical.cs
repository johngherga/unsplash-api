using System.Text.Json.Serialization;

namespace UnsplashAPI.models.image.response
{
    public class Historical
    {
        [JsonPropertyName("change")]
        public int Change { get; set; }
    }
}
