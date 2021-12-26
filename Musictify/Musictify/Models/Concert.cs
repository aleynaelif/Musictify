using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class Concert
    {
        public int ConcertID { get; set; }
        public int StadiumID { get; set; }
        public Stadium Stadium { get; set; }

        [DataType(DataType.Date)]
        public DateTime ConcertDate { get; set; }

    }
}
