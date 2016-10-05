using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIAHTTPS.Data;
using Microsoft.EntityFrameworkCore;

namespace SIAHTTPS.APIs
{
    [Produces("application/json")]
    [Route("api/Aircrafts")]
    public class AircraftsController : Controller
    {
        public ApplicationDbContext Database { get; }

        public AircraftsController()
        {
            Database = new ApplicationDbContext();
        }

        // GET: api/Aircrafts
        [HttpGet]
        public JsonResult Get()
        {
            List<object> aircraftList = new List<object>();
            var aircrafts = Database.Aircrafts;

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
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Aircrafts
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Aircrafts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
