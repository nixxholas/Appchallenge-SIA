using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAHTTPS.Models
{
    public class Flight
    {
        public long FlightId { get; set; }
        public DateTime ETA { get; set; }
        public DateTime TakeoffDT { get; set; }
        public DateTime TouchDownDT { get; set; }
        public StartTermFlights StartTermFlight { get; set; }
        public EndTermFlights EndTermFlight { get; set; }
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }
        public List<FlightTickets> FlightTickets { get; set; }
    }
}
