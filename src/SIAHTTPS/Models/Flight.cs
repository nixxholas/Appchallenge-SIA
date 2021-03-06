﻿using System;
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
    }
}
