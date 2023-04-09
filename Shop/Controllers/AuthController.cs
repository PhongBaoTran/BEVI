using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
using System.Security.Claims;
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

        [AllowAnonymous]
        public async Task<IActionResult> TaskLogin(string name, string password)
        {
            var user = await GetUserByNameAndPassword(name, password);
            if(user.name != null)
            {
                var claims = new[] {
                    new Claim(ClaimTypes.Name, user.fullname),
                    new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                    new Claim(ClaimTypes.StreetAddress, user.address.ToString()),
                    new Claim(ClaimTypes.MobilePhone, user.phone.ToString()),
                    new Claim(ClaimTypes.Role, user.role)};
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));
                return Json(true);
            }
            return Json(false);
        }

        [AllowAnonymous]
        public async Task<UserModel> GetUserByNameAndPassword(string name, string password)
        {
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();
            var query = "select * from users where username = '" + name
                + "' and userpassword = '" + password + "'";
            using var command = new MySqlCommand(query, db);
            using var r = await command.ExecuteReaderAsync();

            UserModel user = new UserModel();
            while(await r.ReadAsync())
            {
                user.id = r.GetInt32(0);
                user.name = r.GetString(1);
                user.email = r.GetString(2);
                user.role = r.GetString(4);
                user.fullname = r.GetString(5);
                user.gender = r.GetBoolean(6);
                user.address = r.GetString(7);
                user.phone = r.GetString(8);
            }

            await db.CloseAsync();
            return user;
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
    }
}
