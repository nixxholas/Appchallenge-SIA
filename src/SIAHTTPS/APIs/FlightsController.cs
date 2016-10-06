using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SIAHTTPS.Data;
using SIAHTTPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                //List<AircraftFlights> aircraftflights = flight.AircraftFlights;

                //foreach (AircraftFlights af in aircraftflights)
                //{
                //    aircraftIds.Add(af.AircraftId);
                //}

                List<long> airportIdList = new List<long>();
                //List<StartTermFlights> airportflights = flight.AirportFlights;

                //foreach (StartTermFlights apf in airportflights)
                //{
                //    airportIdList.Add(apf.AirportId);
                //}

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
            
            object result = new
            {
                flightId = aflight.FlightId,
                eta = aflight.ETA,
                takeOffDt = aflight.TakeoffDT,
                touchdownDt = aflight.TouchDownDT,
                flightNumber = aflight.Aircraft.FlightNumber,
                startAirportId = aflight.StartTermFlight.Terminal.Airport.IATACode,
                endAirportId = aflight.EndTermFlight.Terminal.Airport.IATACode
            };

            return new JsonResult(result);
        }

        // GET api/GetFlightsRoute/FromAirport&ToAirport
        // Allows us to obtain all flight data from one date to another
        [HttpGet("GetFlightsRoute/{FROM}&{TO}")]
        public async Task<IActionResult> GetFlightsRoute(string FROM, string TO) // Airport Code, i.e. SIN
        {
            List<object> flights = new List<object>();

            try
            {
                var foundFlights = _database.Flights
                    .Where(input => input.StartTermFlight.Terminal.Airport.IATACode == FROM)
                    .Where(input => input.EndTermFlight.Terminal.Airport.IATACode == TO);

                foreach (var flight in foundFlights)
                {
                    flights.Add(new
                    {
                        FlightId = flight.FlightId,
                        DepartureAirport = flight.StartTermFlight.Terminal.Airport.IATACode,
                        DepartureCity = flight.StartTermFlight.Terminal.Airport.City,
                        TakeOffDT = flight.TakeoffDT,
                        ArrivalAirport = flight.EndTermFlight.Terminal.Airport.IATACode,
                        ArrivalCity = flight.EndTermFlight.Terminal.Airport.City,
                        TouchDownDT = flight.TouchDownDT,
                        ETA = flight.ETA,
                        FlightTickets = flight.FlightTickets
                    });
                }

                return new JsonResult(flights);
            }
            catch (Exception e)
            {
                //Create a fail message anonymous object
                //This anonymous object only has one Message property 
                //which contains a simple string message
                object httpFailRequestResultMessage =
                                    new
                                    {
                                        Message = "Unable to obtain the information due to" +
                                    "the following error:" + e.ToString() + "."
                                    };
                //Return a bad http response message to the client
                return BadRequest(httpFailRequestResultMessage);
            }
        }

        // GET api/GetRouteTicketHistory/FlightNumber
        // Allows us to obtain all flight data from one date to another
        [HttpGet("GetRouteTicketHistory/{FN}")]
        public async Task<IActionResult> GetRouteTicketHistory(string FN) // Flight Number i.e. SQ873
        {
            List<object> tickets = new List<object>();

            try
            {
                var foundTickets = _database.FlightTickets
                    .Where(input => input.Flight.Aircraft.FlightNumber.Equals(FN))
                    .Where(input => input.Flight.TakeoffDT < DateTime.Now);

                foreach (var ticket in foundTickets)
                {
                    tickets.Add(new
                    {
                        Flight = ticket.Flight,
                        FlightNumber = ticket.Flight.Aircraft.FlightNumber,
                        TicketType = ticket.Ticket.TicketType,
                        ETA = ticket.Flight.ETA,
                        TouchDownDT = ticket.Flight.TouchDownDT,
                        Price = ticket.Price,
                        Quantity = ticket.Quantity
                        //FlightTickets = flight.FlightTickets
                    });
                }

                return new JsonResult(tickets);
            }
            catch (Exception e)
            {
                //Create a fail message anonymous object
                //This anonymous object only has one Message property 
                //which contains a simple string message
                object httpFailRequestResultMessage =
                                    new
                                    {
                                        Message = "Unable to obtain the information due to" +
                                    "the following error:" + e.ToString() + "."
                                    };
                //Return a bad http response message to the client
                return BadRequest(httpFailRequestResultMessage);
            }
        }

        // GET api/GetRouteTicketHistory/FlightNumber
        // Allows us to obtain all flight data from one date to another
        [HttpGet("GetFlightSpecificHistory/{FN}&{DT}")]
        public async Task<IActionResult> GetFlightSpecificHistory(string FN, string DT) // Flight Number i.e. SQ873
        {
            List<object> tickets = new List<object>();

            try
            {
                DateTime DateChosen = DateTime.ParseExact(DT, "ddMMyyyy", null);

                var foundTickets = _database.FlightTickets
                    .Where(input => input.Flight.Aircraft.FlightNumber.Equals(FN))
                    .Where(input => input.Flight.TakeoffDT < DateChosen);

                foreach (var ticket in foundTickets)
                {
                    tickets.Add(new
                    {
                        Flight = ticket.Flight,
                        FlightNumber = ticket.Flight.Aircraft.FlightNumber,
                        TicketType = ticket.Ticket.TicketType,
                        ETA = ticket.Flight.ETA,
                        TouchDownDT = ticket.Flight.TouchDownDT,
                        Price = ticket.Price,
                        Quantity = ticket.Quantity
                        //FlightTickets = flight.FlightTickets
                    });
                }

                return new JsonResult(tickets);
            }
            catch (Exception e)
            {
                //Create a fail message anonymous object
                //This anonymous object only has one Message property 
                //which contains a simple string message
                object httpFailRequestResultMessage =
                                    new
                                    {
                                        Message = "Unable to obtain the information due to" +
                                    "the following error:" + e.ToString() + "."
                                    };
                //Return a bad http response message to the client
                return BadRequest(httpFailRequestResultMessage);
            }
        }

        // GET api/GetRouteAverageQty/FromAirport&ToAirport
        // Allows us to obtain all flight data from one date to another
        [HttpGet("GetRouteQts/{FROM}&{TO}")]
        public async Task<IActionResult> GetRouteQts(string FROM, string TO) // Airport Code, i.e. SIN
        {
            List<object> tickets = new List<object>();

            try
            {
                var foundTickets = _database.FlightTickets
                    .Where(input => input.Flight.StartTermFlight.Terminal.Airport.IATACode == FROM)
                    .Where(input => input.Flight.EndTermFlight.Terminal.Airport.IATACode == TO);

                foreach (var ticket in foundTickets)
                {
                    tickets.Add(new
                    {
                        Flight = ticket.Flight,
                        FlightNumber = ticket.Flight.Aircraft.FlightNumber,
                        TicketType = ticket.Ticket.TicketType,
                        ETA = ticket.Flight.ETA,
                        TouchDownDT = ticket.Flight.TouchDownDT,
                        //FlightTickets = flight.FlightTickets
                    });
                }

                return new JsonResult(tickets);
            }
            catch (Exception e)
            {
                //Create a fail message anonymous object
                //This anonymous object only has one Message property 
                //which contains a simple string message
                object httpFailRequestResultMessage =
                                    new
                                    {
                                        Message = "Unable to obtain the information due to" +
                                    "the following error:" + e.ToString() + "."
                                    };
                //Return a bad http response message to the client
                return BadRequest(httpFailRequestResultMessage);
            }
        }

        // GET api/GetFlightsBetween/DateFrom&DateTo
        // Allows us to obtain all flight data from one date to another
        [HttpGet("GetFlightsBetween/{BEF}&{AFT}")]
        public async Task<IActionResult> GetFlightsBetween(string BEF, string AFT)
        {
            List<object> flights = new List<object>();

            try
            {
                DateTime Start = DateTime.ParseExact(BEF, "ddMMyyyy", null);
                DateTime End = DateTime.ParseExact(AFT, "ddMMyyyy", null);

                var foundFlights = _database.Flights
                    .Where(input => input.TakeoffDT >= Start)
                    .Where(input => input.TakeoffDT <= End);

               foreach (var flight in foundFlights)
                {
                    flights.Add(new
                    {
                        FlightId = flight.FlightId,
                        TakeOffDT = flight.TakeoffDT,
                        TouchDownDT = flight.TouchDownDT,
                        ETA = flight.ETA,
                        FlightTickets = flight.FlightTickets
                    });
                }

                return new JsonResult(flights);
            } catch (Exception e)
            {
                //Create a fail message anonymous object
                //This anonymous object only has one Message property 
                //which contains a simple string message
                object httpFailRequestResultMessage =
                                    new
                                    {
                                        Message = "Unable to obtain the information due to" +
                                    "the following error:" + e.ToString() + "."
                                    };
                //Return a bad http response message to the client
                return BadRequest(httpFailRequestResultMessage);
            }   
        }

        // GET api/GetFlightsBefore/DateFrom
        // Allows us to obtain all flight data before a specific date
        [HttpGet("GetFlightsBefore/{BEF}")]
        public async Task<IActionResult> GetFlightsBetween(string BEF)
        {
            List<object> flights = new List<object>();

            try
            {
                DateTime Start = DateTime.ParseExact(BEF, "ddMMyyyy", null);

                var foundFlights = _database.Flights
                    .Where(input => input.TakeoffDT < Start);

                foreach (var flight in foundFlights)
                {
                    flights.Add(new
                    {
                        FlightId = flight.FlightId,
                        TakeOffDT = flight.TakeoffDT,
                        TouchDownDT = flight.TouchDownDT,
                        ETA = flight.ETA,
                        FlightTickets = flight.FlightTickets
                    });
                }

                return new JsonResult(flights);
            }
            catch (Exception e)
            {
                //Create a fail message anonymous object
                //This anonymous object only has one Message property 
                //which contains a simple string message
                object httpFailRequestResultMessage =
                                    new
                                    {
                                        Message = "Unable to obtain the information due to" +
                                    "the following error:" + e.ToString() + "."
                                    };
                //Return a bad http response message to the client
                return BadRequest(httpFailRequestResultMessage);
            }
        }

        // GET api/GetFlightsAfter/Datefrom
        // Allows us to obtain all flight data after a particular date
        [HttpGet("GetFlightsBefore/{BEF}")]
        public async Task<IActionResult> GetFlightsAfter(string AFT)
        {
            List<object> flights = new List<object>();

            try
            {
                DateTime Start = DateTime.ParseExact(AFT, "ddMMyyyy", null);

                var foundFlights = _database.Flights
                    .Where(input => input.TakeoffDT > Start);

                foreach (var flight in foundFlights)
                {
                    flights.Add(new
                    {
                        FlightId = flight.FlightId,
                        TakeOffDT = flight.TakeoffDT,
                        TouchDownDT = flight.TouchDownDT,
                        ETA = flight.ETA,
                        FlightTickets = flight.FlightTickets
                    });
                }

                return new JsonResult(flights);
            }
            catch (Exception e)
            {
                //Create a fail message anonymous object
                //This anonymous object only has one Message property 
                //which contains a simple string message
                object httpFailRequestResultMessage =
                                    new
                                    {
                                        Message = "Unable to obtain the information due to" +
                                    "the following error:" + e.ToString() + "."
                                    };
                //Return a bad http response message to the client
                return BadRequest(httpFailRequestResultMessage);
            }
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
        }
    }
}