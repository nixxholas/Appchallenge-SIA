using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAHTTPS.Models
{
    public class Flight
    {
        public long FlightId { get; set; }
        public long ETA { get; set; }
        public DateTime TakeoffDT { get; set; }
        public DateTime TouchDownDT { get; set; }
        public StartTermFlight StartTermFlight { get; set; }
        public EndTermFlight EndTermFlight { get; set; }
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }
        public List<FlightTicket> FlightTickets { get; set; }
        public long ParentFlightId { get; set; } // If this is not 0, this flight is after a layover.
        public long LayoverDuration { get; set; } // If this parentflight is not 0, this will be required..
    }
}
