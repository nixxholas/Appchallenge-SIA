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
    [Route("api/Aircrafts")]
    public class AircraftsController : ControllerExtension
    {
        public AircraftsController(UserManager<ApplicationUser> userManager) : base(userManager)
        {

        }

        // GET: api/Aircrafts
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            List<object> aircraftList = new List<object>();
            var aircrafts = _database.Aircrafts;

            foreach (var aircraft in aircrafts)
            {
                aircraftList.Add(new
                {
                    AircraftId = aircraft.AircraftId,
                    Model = aircraft.Model,
                    Brand = aircraft.Brand,
                    FlightNumber = aircraft.FlightNumber
                });
            }

            return new JsonResult(aircraftList);
        }

        // GET: api/Aircrafts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                string flightNo = "SQ" + id;

                var foundAircraft = _database.Aircrafts
                    .Include(input => input.Flights)
                    .Where(input => input.FlightNumber == flightNo).Single();

                var response = new
                {
                    AircraftId = foundAircraft.AircraftId,
                    Brand = foundAircraft.Brand,
                    Model = foundAircraft.Model,
                    FlightNumber = foundAircraft.FlightNumber,
                    Flights = foundAircraft.Flights
                };

                return new JsonResult(response);
            } catch (Exception e)
            {
                //Create a fail message anonymous object
                //This anonymous object only has one Message property 
                //which contains a simple string message
                object httpFailRequestResultMessage =
                                    new { Message = "Unable to obtain Aircraft information due to" + 
                                    "the following error:" + e.ToString() + "." };
                //Return a bad http response message to the client
                return BadRequest(httpFailRequestResultMessage);
            }
        }
        
        // POST: api/Aircrafts
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            string customMessage = "";
            string format = "dd/MM/yyyy";
            //Reconstruct a useful object from the input string value. 
            dynamic aircraftNewInput = JsonConvert.DeserializeObject<dynamic>(value);

            Aircraft Aircraft = new Aircraft();
            try
            {
                Aircraft.Brand = aircraftNewInput.Brand.Value;
                Aircraft.Model = aircraftNewInput.Model.Value;
                Aircraft.FlightNumber = aircraftNewInput.FlightNumber.Value;

                _database.Aircrafts.Add(Aircraft);
                _database.SaveChanges();
            } catch (Exception e)
            {
                if (e.InnerException.Message
                          .Contains("Aircraft_FlightNumber_UniqueConstraint") == true)
                {
                    customMessage = "Unable to save Aircraft record due " +
                                  "to another record having the same name as : " +
                                  aircraftNewInput.FlightNumber.Value;
                    //Create a fail message anonymous object that has one property, Message.
                    //This anonymous object's Message property contains a simple string message
                    object httpFailRequestResultMessage = new { Message = customMessage };
                    //Return a bad http request message to the client
                    return BadRequest(httpFailRequestResultMessage);
                }
            }

            //If there is no runtime error in the try catch block, the code execution
            //should reach here. Sending success message back to the client.

            //******************************************************
            //Construct a custom message for the client
            //Create a success message anonymous object which has a 
            //Message member variable (property)
            var successRequestResultMessage = new
            {
                Message = "Saved Aircraft record"
            };

            //Create a OkObjectResult class instance, httpOkResult.
            //When creating the object, provide the previous message object into it.
            OkObjectResult httpOkResult =
                        new OkObjectResult(successRequestResultMessage);
            //Send the OkObjectResult class object back to the client.
            return httpOkResult;
        }
        
        // PUT: api/Aircrafts/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            string customMessage = "";
            string format = "dd/MM/yyyy";
            var aircraftChangeInput = JsonConvert.DeserializeObject<dynamic>(value);

            try
            {
                var foundAircraft = _database.Aircrafts
                    .Where(input => input.FlightNumber == "SQ" + id).Single();

                foundAircraft.Brand = aircraftChangeInput.Brand.Value;
                foundAircraft.Model = aircraftChangeInput.Model.Value;
                foundAircraft.FlightNumber = aircraftChangeInput.FlightNumber.Value;

                _database.Aircrafts.Update(foundAircraft);
                _database.SaveChanges();
            }
            catch (Exception e)
            {
                if (e.InnerException.Message
                          .Contains("Aircraft_FlightNumber_UniqueConstraint") == true)
                {
                    customMessage = "Unable to save Aircraft record due " +
                                  "to another record having the same name as : " +
                                  aircraftChangeInput.FlightNumber.Value;
                    //Create a fail message anonymous object that has one property, Message.
                    //This anonymous object's Message property contains a simple string message
                    object httpFailRequestResultMessage = new { Message = customMessage };
                    //Return a bad http request message to the client
                    return BadRequest(httpFailRequestResultMessage);
                }
            }
            //If there is no runtime error in the try catch block, the code execution
            //should reach here. Sending success message back to the client.

            //******************************************************
            //Construct a custom message for the client
            //Create a success message anonymous object which has a 
            //Message member variable (property)
            var successRequestResultMessage = new
            {
                Message = "Updated Aircraft record"
            };

            //Create a OkObjectResult class instance, httpOkResult.
            //When creating the object, provide the previous message object into it.
            OkObjectResult httpOkResult =
                        new OkObjectResult(successRequestResultMessage);
            //Send the OkObjectResult class object back to the client.
            return httpOkResult;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string customMessage = "";

            try
            {
                var foundAircraft = _database.Aircrafts
                    .Where(input => input.FlightNumber == "SQ" + id).Single();

                _database.Aircrafts.Remove(foundAircraft);
                _database.SaveChanges();                
            } catch (Exception e)
            {
                customMessage = "Unable to delete Aircraft record due " +
                                    "to: " + e.ToString();
                //Create a fail message anonymous object that has one property, Message.
                //This anonymous object's Message property contains a simple string message
                object httpFailRequestResultMessage = new { Message = customMessage };
                //Return a bad http request message to the client
                return BadRequest(httpFailRequestResultMessage);
            }

            //If there is no runtime error in the try catch block, the code execution
            //should reach here. Sending success message back to the client.

            //******************************************************
            //Construct a custom message for the client
            //Create a success message anonymous object which has a 
            //Message member variable (property)
            var successRequestResultMessage = new
            {
                Message = "Deleted Aircraft record"
            };

            //Create a OkObjectResult class instance, httpOkResult.
            //When creating the object, provide the previous message object into it.
            OkObjectResult httpOkResult =
                        new OkObjectResult(successRequestResultMessage);
            //Send the OkObjectResult class object back to the client.
            return httpOkResult;
        }
    }
}
