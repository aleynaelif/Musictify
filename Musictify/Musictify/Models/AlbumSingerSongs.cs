using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class AlbumSingerSongs
    {
        public PlaylistSongs PlaylistSongsDetails { get; set; }
        public SingerSongs SingerSongsDetails { get; set; }
        public Songs SongsDetails { get; set; }
    }
}
