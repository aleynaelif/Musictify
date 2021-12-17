using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class Singer
    {
        public int SingerID { get; set; }
        public string SingerName { get; set; }
        public DateTime Birthday { get; set; }
        public int SingerAge { get; set; }
        public string SingerDescription { get; set; }
        public string ImageUrl { get; set; }
    }
}
