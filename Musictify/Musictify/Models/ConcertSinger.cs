using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class ConcertSinger
    {
        public int ConcertSingerID { get; set; }
        public int SingerID { get; set; }
        public Singer Singer { get; set; }
        public int ConcertID { get; set; }
        public Concert Concert { get; set; }
    }
}
