using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class Singer
    {
        public int SingerID { get; set; }
        public string SingerName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public int SingerAge { get; set; }
        public string SingerDescription { get; set; }
        public string ImageUrl { get; set; }
    }
}
