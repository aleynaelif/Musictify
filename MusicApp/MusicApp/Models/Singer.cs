using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Singer
    {
        public int  SingerID { get; set; }
        public string SingerName { get; set; }
        public ICollection<Albums> Albums { get; set; }
    }
}
