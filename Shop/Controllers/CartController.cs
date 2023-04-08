using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        public IConfiguration Configuration { get; }

        public CartController(IConfiguration config)
        {
            Configuration = config;
        }

        [Authorize]
        public async Task<IActionResult> Cart()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();
            var query = "select * from carts where userid = " + id;
            using var command = new MySqlCommand(query, db);
            using var r = await command.ExecuteReaderAsync();

            CartModel cart = new CartModel();
            while (await r.ReadAsync())
            {
                ProductModel p = new ProductModel();
                p.id = r.GetInt32(0);
                p.name = r.GetString(1);
                p.description = r.GetString(2);
                p.price = r.GetDecimal(3);
                p.lastprice = r.GetDecimal(4);
                p.categoryid = r.GetInt32(5);
                p.quantity = await GetProductQuantity(p.id);
                cart.items.Add(p);
            }

            await db.CloseAsync();
            return View(cart);
        }

        [Authorize]
        public async Task<int> GetProductQuantity(int productid)
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();
            var query = "select quantity from carts where userid = " + id + " and productid = " + productid;
            using var command = new MySqlCommand(query, db);
            using var r = await command.ExecuteReaderAsync();

            int count = 0;
            while (await r.ReadAsync())
            {
                count = r.GetInt32(0);
            }

            await db.CloseAsync();
            return count;
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetCartCount()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null) return Json(null);

            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();
            var query = "select count(userid) from carts where userid = " + id;
            using var command = new MySqlCommand(query, db);
            using var r = await command.ExecuteReaderAsync();

            int count = 0;
            while (await r.ReadAsync())
            {
                count = r.GetInt32(0);
            }

            await db.CloseAsync();
            return Json(count);
        }

        [Authorize]
        public async Task<IActionResult> AddToCart(string productid, string quantity)
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int count = int.Parse(quantity);
            int current = await GetProductQuantity(count);

            if (await CheckProductExisted(productid))
            {
                UpdateCart(productid, count + current);
            }
            else
            {
                CreateCart(productid, count);
            }

            return Json(true);
        }

        public async Task<bool> CheckProductExisted(string productid)
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();

            var query1 = "select count(productid) from carts where productid = " + productid
                + " and userid = " + id;
            using var cmd1 = new MySqlCommand(query1, db);
            using var r1 = await cmd1.ExecuteReaderAsync();

            bool existed = false;
            while (await r1.ReadAsync())
            {
                existed = r1.GetInt32(0) != 0;
            }

            db.CloseAsync();
            return existed;
        }

        public async void UpdateCart(string productid, int quantity)
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();

            var query2 = "update carts set quantity = " + quantity
                + " where userid = " + id
                + " and productid = " + productid;
            using var cmd2 = new MySqlCommand(query2, db);
            await cmd2.ExecuteNonQueryAsync();

            await db.CloseAsync();
        }

        public async void CreateCart(string productid, int quantity)
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();

            var query2 = "insert into carts values (" + id + "," + productid + "," + quantity + ")";
            using var cmd2 = new MySqlCommand(query2, db);
            await cmd2.ExecuteNonQueryAsync();

            await db.CloseAsync();
        }
    }
}
