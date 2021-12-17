using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class Producer
    {
        public int ProducerID { get; set; }
        public string ProducerName { get; set; }
        public DateTime Birthday { get; set; }
        public int ProducerAge { get; set; }
        public string ProducerDescription { get; set; }
        public string ImageUrl { get; set; }
    }
}
