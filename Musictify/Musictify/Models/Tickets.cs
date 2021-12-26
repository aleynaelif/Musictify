using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class Tickets
    {
        public int TicketsID { get; set; }

        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        public int TicketPricingID { get; set; }
        public TicketPricing TicketPricing { get; set; }
        public int SeatRow { get; set; }
        public int SeatColumn { get; set; }

    }
}
