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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration Configuration { get; }

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            Configuration = config;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();
            var query = "select * from products";
            using var command = new MySqlCommand(query, db);
            using var r = await command.ExecuteReaderAsync();

            List<ProductModel> list = new List<ProductModel>();
            while(await r.ReadAsync())
            {
                ProductModel p = new ProductModel()
                {
                    id = r.GetInt32(0),
                    name = r.GetString(1),
                    description = r.GetString(2),
                    price = r.GetDecimal(3),
                    lastprice = r.GetDecimal(4),
                    categoryid = r.GetInt32(5),
                };
                p.img.Add(await GetProductImg(p.id));
                list.Add(p);
            };
            await db.CloseAsync();
            return View(list);
        }

        public async Task<string> GetProductImg(int id)
        {
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();
            var query = "select url from productimages where productid = " + id + " limit 1";
            using var command = new MySqlCommand(query, db);
            using var r = await command.ExecuteReaderAsync();

            string img = "";
            while (await r.ReadAsync()) img = r.GetString(0);
            await db.CloseAsync();
            return img;
        }

        public async Task<IActionResult> ProductDetail(int id)
        {
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();
            var query = "select * from products where productid = " + id;
            using var command = new MySqlCommand(query, db);
            using var r = await command.ExecuteReaderAsync();

            ProductModel P = new ProductModel();
            while(await r.ReadAsync())
            {
                P.id = r.GetInt32(0);
                P.name = r.GetString(1);
                P.description = r.GetString(2);
                P.price = r.GetDecimal(3);
                P.lastprice = r.GetDecimal(4);
                P.categoryid = r.GetInt32(5);
                P.img = await GetProductImgs(P.id);
            }
            await db.CloseAsync();

            return View(P);
        }

        public async Task<List<string>> GetProductImgs(int id)
        {
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();
            var query = "select url from productimages where productid = " + id;
            using var command = new MySqlCommand(query, db);
            using var r = await command.ExecuteReaderAsync();

            List<string> list = new List<string>();
            while(await r.ReadAsync())
            {
                string str = r.GetString(0);
                list.Add(str);
            }
            await db.CloseAsync();
            return list;
        }

        public async Task<IActionResult> Search(string str)
        {
            str = str == null ? "" : str.ToLower();
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();
            var query = "select * from products " +
                "where name like '%" + str + "%' or description like '%" + str + "%'";
            using var command = new MySqlCommand(query, db);
            using var r = await command.ExecuteReaderAsync();

            List<ProductModel> list = new List<ProductModel>();
            while (await r.ReadAsync())
            {
                ProductModel p = new ProductModel()
                {
                    id = r.GetInt32(0),
                    name = r.GetString(1),
                    description = r.GetString(2),
                    price = r.GetDecimal(3),
                    lastprice = r.GetDecimal(4),
                    categoryid = r.GetInt32(5),
                };
                p.img.Add(await GetProductImg(p.id));
                list.Add(p);
            };
            await db.CloseAsync();
            return View(list);
        }

        public IActionResult Info()
        {
            return View();
        }
    }
}
