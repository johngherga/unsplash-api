using System.Text.Json.Serialization;

namespace UnsplashAPI.models.image
{
    public class Position
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }
}
