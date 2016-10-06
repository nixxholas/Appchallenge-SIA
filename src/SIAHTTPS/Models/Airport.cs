using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAHTTPS.Models
{
    public class Airport
    {
        public long AirportId { get; set; }
        public string IATACode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string CountryAbbreviation { get; set; }
        public List<Terminal> Terminals { get; set; }
    }
}
