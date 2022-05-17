using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UnsplashAPI.models.image.response
{
    public class ImageResponse
    {

        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }
        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }
        [JsonPropertyName("width")]
        public int Width { get; set; } = 0;
        [JsonPropertyName("height")]
        public int Height { get; set; } = 0;
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("blur_hash")]
        public string BlurHash { get; set; }
        [JsonPropertyName("downloads")]
        public int Downloads { get; set; } = 0;
        [JsonPropertyName("likes")]
        public int Likes { get; set; } = 0;
        [JsonPropertyName("liked_by_user")]
        public bool LikedByUser { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("exif")]
        public Exif Exif { get; set; }
        [JsonPropertyName("location")]
        public Location Location { get; set; }
        [JsonPropertyName("current_user_collections")]
        public List<CurrentUserCollections> CurrentUserCollections { get; set; }
        [JsonPropertyName("urls")]
        public Urls Urls { get; set; }
        [JsonPropertyName("links")]
        public Links Links { get; set; }
        [JsonPropertyName("user")]
        public User User { get; set; }
    }
}
