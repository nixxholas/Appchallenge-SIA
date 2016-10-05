using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAHTTPS.Models
{
    public class FlightTickets
    {
        public long FlightId { get; set; }
        public Flight Flight { get; set; }
        public long TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
