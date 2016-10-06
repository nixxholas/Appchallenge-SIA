using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIAHTTPS.Data;
using SIAHTTPS.Models;
using SIAHTTPS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAHTTPS.APIs
{
    public class ControllerExtension : Controller
    {
        protected readonly ApplicationDbContext _database;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;

        //public ApplicationDbContext _database { get; }

        // The Extension Class Constructor
        public ControllerExtension(ApplicationDbContext database)
        {
            _database = new ApplicationDbContext();
        }

        //Default constructor required
        public ControllerExtension()
        {
            _database = new ApplicationDbContext();
        }

        public ControllerExtension(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        public UserManager<ApplicationUser> GetUserManager()
        {
            return _userManager;
        }

        // http://blog.stephencleary.com/2012/07/dont-block-on-async-code.html - Best Practice Applied
        public async Task<ApplicationUser> GetCurrentUserAsync()
        {
            //Error with this line. HttpContext.User is not returning any form of user identification
            return await _userManager.GetUserAsync(HttpContext.User); // Synchronized
        }
    }
}
