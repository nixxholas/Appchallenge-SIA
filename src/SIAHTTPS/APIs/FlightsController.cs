using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIAHTTPS.Data;
using SIAHTTPS.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SIAHTTPS.APIs
{
    [Route("api/[controller]")]
    public class FlightsController : ControllerExtension
    {
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            List<object> flightsList = new List<object>();

            var flights = _database.Flights;

            foreach (var flight in flights)
            {
                List<int> aircraftIds = new List<int>();
                List<AircraftFlights> aircraftflights = flight.AircraftFlights;

                foreach (AircraftFlights af in aircraftflights)
                {
                    aircraftIds.Add(af.AircraftId);
                }

                List<long> airportIdList = new List<long>();
                List<AirportFlights> airportflights = flight.AirportFlights;

                foreach (AirportFlights apf in airportflights)
                {
                    airportIdList.Add(apf.AirportId);
                }

                List<FlightTickets> flighttickets = flight.FlightTickets;
                List<long> ticketIds = new List<long>();
                List<decimal> ticketPrices = new List<decimal>();
                List<int> ticketQuantity = new List<int>();

                foreach (FlightTickets ft in flighttickets)
                {
                    ticketIds.Add(ft.TicketId);
                    ticketPrices.Add(ft.Price);
                    ticketQuantity.Add(ft.Quantity);
                }

                flightsList.Add(new
                {
                    flightId = flight.FlightId,
                    eta = flight.ETA,
                    takeOffDt = flight.TakeoffDT,
                    touchdownDt = flight.TouchDownDT,
                    aircraftIds = aircraftIds,
                    airportIds = airportIdList,
                    ticketIds = ticketIds,
                    ticketPrices = ticketPrices,
                    ticketQuantity = ticketQuantity
                });
            }

            return new JsonResult(flightsList);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(long id)
        {
            var aflight = _database.Flights
                .Where(input => input.FlightId == id)
                .Single();

            List<AircraftFlights> aircraftFlights = aflight.AircraftFlights;

            List<int> aircraftIds = new List<int>();
            foreach (AircraftFlights af in aircraftFlights)
            {
                aircraftIds.Add(af.AircraftId);
            }

            List<AirportFlights> airportFlights = aflight.AirportFlights;

            List<long> airportIds = new List<long>();
            foreach (AirportFlights apf in airportFlights)
            {
                airportIds.Add(apf.AirportId);
            }

            object result = new
            {
                flightId = aflight.FlightId,
                eta = aflight.ETA,
                takeOffDt = aflight.TakeoffDT,
                touchdownDt = aflight.TouchDownDT,
                aircraftIds = aircraftIds,
                airportIds = airportIds
            };

            return new JsonResult(result);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}