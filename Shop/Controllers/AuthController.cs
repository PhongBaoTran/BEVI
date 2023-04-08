using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class AuthController : Controller
    {
        public IConfiguration Configuration { get; }

        public AuthController(IConfiguration config)
        {
            Configuration = config;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
    }
}
