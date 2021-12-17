using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class ProducerSongs
    {
        public int ProducerSongsID { get; set; }
        public int ProducerID { get; set; }
        public Producer Producer { get; set; }
        public int SongsID { get; set; }
        public Songs Songs { get; set; }
    }
}
