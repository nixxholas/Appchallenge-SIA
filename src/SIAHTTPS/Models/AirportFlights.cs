using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAHTTPS.Models
{
    public class AirportFlights
    {
        public long AirportId { get; set; }
        public Airport Airport { get; set; }
        public long FlightId { get; set; }
        public Flight Flight { get; set; }
        public long TerminalId { get; set; }
        public Terminal Terminal { get; set; }
    }
}
