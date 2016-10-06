using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SIAHTTPS.Controllers
{
    public class AirportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}