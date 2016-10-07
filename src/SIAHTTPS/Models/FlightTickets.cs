using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAHTTPS.Models
{
    public class FlightTickets
    {
        public long FlightId { get; set; } // Flight Identifier
        public Flight Flight { get; set; } // Which flight this ticket is sold for
        public long TicketId { get; set; } // Ticket Identifier
        public Ticket Ticket { get; set; } // What type of ticket this is
        public decimal Price { get; set; } // Price
        public int Quantity { get; set; } // How many left
        public DateTime PurchaseDate { get; set; } // Date of purchase of the ticket
    }
}
