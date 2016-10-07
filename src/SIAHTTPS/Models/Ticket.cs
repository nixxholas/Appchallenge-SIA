using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAHTTPS.Models
{
    public class Ticket
    {
        public long TicketId { get; set; }
        public string TicketType { get; set; } // First Class
        public string TicketName { get; set; } // For fuck?
        public List<FlightTicket> FlightTickets { get; set; }
    }
}
