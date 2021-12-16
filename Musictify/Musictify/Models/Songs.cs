using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class Songs
    {
        public int SongID { get; set; }
        public string SongName { get; set; }
        public double MinuteLength { get; set; }
        public string Collab { get; set; }
        public string Lyrics { get; set; }
        public int AlbumID { get; set; }
        public Album Album { get; set; }
    }
}
