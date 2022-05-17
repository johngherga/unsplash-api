using System.Text.Json.Serialization;

namespace UnsplashAPI.models.image.response
{
    public class Links
    {
        [JsonPropertyName("self")]
        public string Self { get; set; }
        [JsonPropertyName("html")]
        public string Html { get; set; }
        [JsonPropertyName("download")]
        public string Download { get; set; }
        [JsonPropertyName("download_location")]
        public string DownloadLocation { get; set; }
    }
}
