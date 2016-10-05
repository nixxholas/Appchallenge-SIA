using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAHTTPS.Models
{
    public class Aircraft
    {
        public int AircraftId { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string FlightNumber { get; set; }  // SQ 872
        public List<AircraftFlights> AircraftFlights { get; set; }
    }
}
