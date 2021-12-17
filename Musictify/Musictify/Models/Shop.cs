using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class Shop
    {
        public int ShopID { get; set; }
        public int VinylID { get; set; }
        public Vinyl Vinyl { get; set; }
        public int CDID { get; set; }
        public CD CD { get; set; }
    }
}
