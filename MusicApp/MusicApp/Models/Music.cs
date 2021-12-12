using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Music
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Singer { get; set; }
        public string Description { get; set; }
        public string Songs { get; set; }
        public int ReleaseDate { get; set; }
        public double Rate { get; set; }

    }
}
