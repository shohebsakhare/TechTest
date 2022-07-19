using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TechTestCore.Model
{
    public class photoData
    {
        public int albumId { get; set; }
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
    }
    public class albumData
    {
        public int userId { get; set; }
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public List<photoData> photo_data { get; set; }
    }
   
}
