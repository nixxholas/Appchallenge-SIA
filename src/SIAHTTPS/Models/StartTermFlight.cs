using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAHTTPS.Models
{
    public class StartTermFlight
    {
        public long FlightId { get; set; }
        public long TerminalId { get; set; }
        public Flight Flight { get; set; }
        public Terminal Terminal { get; set; }
    }
}
