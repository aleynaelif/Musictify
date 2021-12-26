using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class PlaylistSongsSinger
    {
        public Playlist PlaylistDetails { get; set; }
        public Songs SongsDetails { get; set; }
        public Singer SingerDetails { get; set; }
    }
}
