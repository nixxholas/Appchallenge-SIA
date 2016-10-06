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
    [Route("api/Tickets")]
    public class TicketsController : ControllerExtension
    {
        public TicketsController(UserManager<ApplicationUser> userManager) : base(userManager)
        {

        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            List<object> ticketList = new List<object>();
            var tickets = _database.Tickets;

            foreach (var ticket in tickets)
            {
                ticketList.Add(new
                {
                    TicketId = ticket.TicketId,
                    Model = ticket.TicketType,
                    Brand = ticket.TicketName,
                    // Not a good design to have this here. Has a shitload of data..
                    // Better to allow the admin to manage or see via the specific Get(i) API.
                    //FlightTickets = ticket.FlightTickets 
                });
            }

            return new JsonResult(ticketList);
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string ticketType) // TicketType i.e => "First Class" or "Suite" whatever..
        {
            try
            {
                var foundTicket = _database.Tickets
                    .Include(input => input.FlightTickets)
                    .Where(input => input.TicketType == ticketType).Single();

                var response = new
                {
                    TicketId = foundTicket.TicketId,
                    TicketType = foundTicket.TicketType,
                    Model = foundTicket.TicketName,
                    FlightTickets = foundTicket.FlightTickets
                };

                return new JsonResult(response);
            } catch (Exception e)
            {
                //Create a fail message anonymous object
                //This anonymous object only has one Message property 
                //which contains a simple string message
                object httpFailRequestResultMessage =
                                    new { Message = "Unable to obtain Ticket information due to" + 
                                    "the following error:" + e.ToString() + "." };
                //Return a bad http response message to the client
                return BadRequest(httpFailRequestResultMessage);
            }
        }
        
        // POST: api/Tickets
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            string customMessage = "";
            string format = "dd/MM/yyyy";
            //Reconstruct a useful object from the input string value. 
            dynamic ticketNewInput = JsonConvert.DeserializeObject<dynamic>(value);

            Ticket Ticket = new Ticket();
            try
            {
                Ticket.TicketName = ticketNewInput.TicketName.Value;
                Ticket.TicketType = ticketNewInput.TicketType.Value;

                _database.Tickets.Add(Ticket);
                _database.SaveChanges();
            } catch (Exception e)
            {
                if (e.InnerException.Message
                          .Contains("Ticket_TicketType_UniqueConstraint") == true)
                {
                    customMessage = "Unable to save Ticket record due " +
                                  "to another record having the same name as : " +
                                  ticketNewInput.FlightNumber.Value;
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
                Message = "Saved Ticket record"
            };

            //Create a OkObjectResult class instance, httpOkResult.
            //When creating the object, provide the previous message object into it.
            OkObjectResult httpOkResult =
                        new OkObjectResult(successRequestResultMessage);
            //Send the OkObjectResult class object back to the client.
            return httpOkResult;
        }
        
        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]string value)
        {
            string customMessage = "";
            string format = "dd/MM/yyyy";
            var ticketChangeInput = JsonConvert.DeserializeObject<dynamic>(value);

            try
            {
                var foundTicket = _database.Tickets
                    .Where(input => input.TicketId == id).Single();

                foundTicket.TicketName = ticketChangeInput.TicketName.Value;
                foundTicket.TicketType = ticketChangeInput.TicketType.Value;

                _database.Tickets.Update(foundTicket);
                _database.SaveChanges();
            }
            catch (Exception e)
            {
                if (e.InnerException.Message
                          .Contains("Ticket_FlightNumber_UniqueConstraint") == true)
                {
                    customMessage = "Unable to save Ticket record due " +
                                  "to another record having the same name as : " +
                                  ticketChangeInput.FlightNumber.Value;
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
                Message = "Updated Ticket record"
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
                var foundTicket = _database.Tickets
                    .Where(input => input.TicketId == id).Single();

                _database.Tickets.Remove(foundTicket); // Hard Delete Row
                _database.SaveChanges();                
            } catch (Exception e)
            {
                customMessage = "Unable to delete Ticket record due " +
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
                Message = "Deleted Ticket record"
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
