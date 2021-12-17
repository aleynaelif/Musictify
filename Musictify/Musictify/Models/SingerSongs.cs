using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class SingerSongs
    {
        public int SingerSongsID { get; set; }
        public int SingerID { get; set; }
        public Singer Singer { get; set; }
        public int SongsID { get; set; }
        public Songs Songs { get; set; }
    }
}
