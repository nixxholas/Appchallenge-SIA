using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAHTTPS.Controllers
{
    public class FlightsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult One()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}
