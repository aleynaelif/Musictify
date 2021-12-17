using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class Concert
    {
        public int ConcertID { get; set; }
        public int StadiumID { get; set; }
        public Stadium Stadium { get; set; }
        public DateTime ConcertDate { get; set; }

    }
}
