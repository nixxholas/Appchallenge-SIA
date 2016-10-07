using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIAHTTPS.Data;
using Microsoft.EntityFrameworkCore;
using SIAHTTPS.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace SIAHTTPS.APIs
{
    [Produces("application/json")]
    [Route("api/Airports")]
    public class AirportsController : ControllerExtension
    {
        // GET: api/Airports
        [HttpGet]
        public IActionResult Get()
        {
            List<object> airportList = new List<object>();
            var airports = _database.Airports
                .Include(input => input.Terminals);

            foreach (var airport in airports)
            {
                //List<object> outgoingFlights = new List<object>();
                //List<object> incomingFlights = new List<object>();

                //foreach (var terminal in airport.Terminals)
                //{
                //    foreach (var startTermFlight in terminal.StartTermFlights)
                //    {
                        
                //    }
                //}

                airportList.Add(new
                {
                    AirportId = airport.AirportId,
                    IATA = airport.IATACode,
                    Country = airport.Country,
                    City = airport.City,
                    CountryCode = airport.CountryCode,
                    CountryAbbreviation = airport.CountryAbbreviation,
                    //FlightsOutgoing = 
                    //Terminals = airport.Terminals
                });
            }

            return new JsonResult(airportList);
        }

        // GET: api/Airports/5
        [HttpGet("{IATA}")]
        public async Task<IActionResult> Get(string IATA)
        {
            try
            {
                var foundAirport = _database.Airports
                   // .Include(input => input.AirportFlights)
                    .Include(input => input.Terminals)
                    .Where(input => input.IATACode == IATA).Single();

                var response = new
                {
                    AirportId = foundAirport.AirportId,
                    IATA = foundAirport.IATACode,
                    Country = foundAirport.Country,
                    City = foundAirport.City,
                    CountryCode = foundAirport.CountryCode,
                    CountryAbbreviation = foundAirport.CountryAbbreviation,
                    //AirportFlights = foundAirport.AirportFlights,
                    Terminals = foundAirport.Terminals
                };

                return new JsonResult(response);
            }
            catch (Exception e)
            {
                //Create a fail message anonymous object
                //This anonymous object only has one Message property 
                //which contains a simple string message
                object httpFailRequestResultMessage =
                                    new
                                    {
                                        Message = "Unable to obtain Aircraft information due to" +
                                    "the following error:" + e.ToString() + "."
                                    };
                //Return a bad http response message to the client
                return BadRequest(httpFailRequestResultMessage);
            }
        }
        // GET: api/Airports/Flights/5
        // Allow us to retrieve the flights for the airport
        [HttpGet("Flights/{IATA}")]
        public async Task<IActionResult> GetAirportFlights(string IATA)
        {
            try
            {
                List<object> airportFlightsList = new List<object>();
                var foundAirport = _database.Airports
                    //.Include(input => input.AirportFlights)
                    .Include(input => input.Terminals)
                    .Where(input => input.IATACode == IATA)
                    .Single();

                /**
                 * We'll have to pull the flights that are specific to this airport.
                 * Airports -> Terminals -> Flights
                 */

                //foreach (var airportFlight in foundAirport.AirportFlights)
                //{
                //    airportFlightsList.Add(new
                //    {
                //        // AirportId = airportFlight.AirportId,
                //        TerminalId = airportFlight.TerminalId,
                //        Terminal = airportFlight.Terminal.TerminalName,
                //        Flight = airportFlight.Flight
                //    });
                //}

                //var response = new
                //{
                //    AirportId = foundAirport.AirportId,
                //    IATA = foundAirport.IATACode,
                //    Country = foundAirport.Country,
                //    City = foundAirport.City,
                //    CountryCode = foundAirport.CountryCode,
                //    CountryAbbreviation = foundAirport.CountryAbbreviation,
                //    AirportFlights = foundAirport.AirportFlights,
                //    Terminals = foundAirport.Terminals
                //};

                return new JsonResult(airportFlightsList);
            }
            catch (Exception e)
            {
                //Create a fail message anonymous object
                //This anonymous object only has one Message property 
                //which contains a simple string message
                object httpFailRequestResultMessage =
                                    new
                                    {
                                        Message = "Unable to obtain Aircraft information due to" +
                                    "the following error:" + e.ToString() + "."
                                    };
                //Return a bad http response message to the client
                return BadRequest(httpFailRequestResultMessage);
            }
        }
    }     
}
