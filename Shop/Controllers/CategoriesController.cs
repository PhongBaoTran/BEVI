using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Shop.Controllers
{
    public class CategoriesController : Controller
    {

        public CategoriesController(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; }

        [HttpGet]
        public async Task<IActionResult> getCatListName()
        {
            try
            {
                MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
                await db.OpenAsync();
                var query = "select categoryid, name from categories";
                using var command = new MySqlCommand(query, db);
                using var r = await command.ExecuteReaderAsync();

                List<CategoryModel> list = new List<CategoryModel>();
                while (await r.ReadAsync())
                {
                    CategoryModel cat = new CategoryModel()
                    {
                        id = r.GetInt32(0),
                        name = r.GetString(1)
                    };
                    list.Add(cat);
                }

                return Json(list);
            }
            catch(Exception ex)
            {
                return Json("error");
            }
        }
    }
}
