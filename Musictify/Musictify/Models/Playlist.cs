using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class Playlist
    {
        public int PlaylistID { get; set; }
        public string PlaylistName { get; set; }
        public string ImageUrl { get; set; }
        public string PlaylistDescription { get; set; }

    }
}
