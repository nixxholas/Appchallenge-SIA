using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAHTTPS.Models
{
    public class AircraftFlights
    {
        public long FlightId { get; set; }
        public Flight Flight { get; set; }
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }
    }
}
