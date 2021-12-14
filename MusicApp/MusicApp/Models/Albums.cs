using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Albums
    {
        [Key]
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }
        public int SingerID { get; set; }
        public Singer Sing { get; set; }
    }
}
