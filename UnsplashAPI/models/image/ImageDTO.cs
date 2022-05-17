using System;
using System.Collections.Generic;
using System.Text;

namespace UnsplashAPI.models.image
{
    public class ImageDTO
    {
        public string ImageId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public int TenDayDownloads { get; set; }
        public double PercentOfTotalDownloads { get; set; }
    }
}
