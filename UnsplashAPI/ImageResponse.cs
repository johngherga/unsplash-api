using System;
using System.Text.Json.Serialization;

namespace UnsplashAPI
{
    public class ImageResponse
    {
        public ImageResponse()
        {
        }

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }
        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }
        [JsonPropertyName("width")]
        public int Width { get; set; }
        [JsonPropertyName("height")]
        public int Height { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("blur_hash")]
        public string BlurHash { get; set; }
        [JsonPropertyName("downloads")]
        public int Downloads { get; set; }
        [JsonPropertyName("likes")]
        public int Likes { get; set; }
        [JsonPropertyName("liked_by_user")]
        public bool LikedByUser { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }

    }

    class Exif
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
