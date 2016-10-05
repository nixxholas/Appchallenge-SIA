using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAHTTPS.Models
{
    public class Airport
    {
        public long AirportId { get; set; }
        public String IATACode { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public String CountryCode { get; set; }
        public String CountryAbbreviation { get; set; }
        public List<Terminal> Terminals { get; set; }
        public List<AirportFlights> AirportFlights { get; set; }
    }
}
