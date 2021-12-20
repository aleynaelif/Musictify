using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class SingerAlbum
    {
        public int ID { get; set; }
        public int AlbumID { get; set; }
        public Album Album { get; set; }
        public int SingerID { get; set; }
        public Singer Singer { get; set; }
    }
}
