using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class PlaylistSongs
    {
        public int PlaylistSongsID { get; set; }
        public int PlaylistID { get; set; }
        public Playlist Playlist { get; set; }
        public int SongsID { get; set; }
        public Songs Songs { get; set; }
    }
}
