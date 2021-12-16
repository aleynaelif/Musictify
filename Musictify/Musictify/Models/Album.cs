using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }
        public string ImageUrl { get; set; }
        public int? ReleaseDate { get; set; }
        public double? Rate { get; set; }
        public int SingerID { get; set; }
        public Singer Singer { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
