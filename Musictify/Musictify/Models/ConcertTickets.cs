using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class ConcertTickets
    {
        public int ConcertTicketsID { get; set; }
        public int ConcertID { get; set; }
        public Concert Concert { get; set; }
        public int TicketsID { get; set; }
        public Tickets Tickets { get; set; }
    }
}
