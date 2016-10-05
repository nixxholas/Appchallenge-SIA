using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAHTTPS.Models
{
    public class Terminal
    {
        public long TerminalId { get; set; }
        public string TerminalName { get; set; }
        public long AirportId { get; set; }
        public Airport Airport { get; set; }
    }
}
