using System.Text.Json.Serialization;

namespace UnsplashAPI.models.image
{
    public class Exif
    {
        [JsonPropertyName("make")]
        public string Make { get; set; }
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("exposure_time")]
        public string ExposureTime { get; set; }
        [JsonPropertyName("aperture")]
        public string Aperture { get; set; }
        [JsonPropertyName("focal_length")]
        public string FocalLength { get; set; }
        [JsonPropertyName("iso")]
        public int Iso { get; set; }
    }
}
