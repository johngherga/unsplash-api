using System.Text.Json.Serialization;

namespace UnsplashAPI.models.image
{
    public class Location
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("position")]
        public Position Position { get; set; }
    }
}
