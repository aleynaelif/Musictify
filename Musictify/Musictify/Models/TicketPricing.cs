using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musictify.Models
{
    public class TicketPricing
    {
        public int TicketPricingID { get; set; }
        public double VipPrice { get; set; }
        public double BackstagePrice { get; set; }
        public double EarlyBirdPrice { get; set; }
        public double NormalPrice { get; set; }

    }
}
