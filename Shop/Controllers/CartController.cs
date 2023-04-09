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

            CartModel cart = await GetCart(id);

            return View(cart);
        }

        public async Task<CartModel> GetCart(string userid)
        {
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();
            var query = "select * from carts where userid = " + userid;
            using var command = new MySqlCommand(query, db);
            using var r = await command.ExecuteReaderAsync();

            CartModel cart = new CartModel();
            while (await r.ReadAsync())
            {
                ProductModel p = new ProductModel();
                p = await GetProductDetail(r.GetInt32(1));
                p.quantity = r.GetInt32(2);
                cart.items.Add(p);
            }

            await db.CloseAsync();
            return cart;
        }

        public async Task<ProductModel> GetProductDetail(int id)
        {
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();
            var query = "select * from products where productid = " + id;
            using var command = new MySqlCommand(query, db);
            using var r = await command.ExecuteReaderAsync();

            ProductModel P = new ProductModel();
            while (await r.ReadAsync())
            {
                P.id = r.GetInt32(0);
                P.name = r.GetString(1);
                P.price = r.GetDecimal(3);
                P.img.Add(await GetProductImg(P.id));
            }
            await db.CloseAsync();

            return P;
        }

        [Authorize]
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
            int current = await GetProductQuantity(int.Parse(productid));

            if (await CheckProductExisted(productid))
            {
                await UpdateCart(productid, count + current);
            }
            else
            {
                await CreateCart(productid, count);
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

        public async Task UpdateCart(string productid, int quantity)
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

        public async Task CreateCart(string productid, int quantity)
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();

            var query2 = "insert into carts values (" + id + "," + productid + "," + quantity + ")";
            using var cmd2 = new MySqlCommand(query2, db);
            await cmd2.ExecuteNonQueryAsync();

            await db.CloseAsync();
        }

        public async Task<IActionResult> RemoveFromCart(string productid, string quantity)
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int c = int.Parse(quantity);

            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();

            var query = (c == 0) ?
                "delete from carts where userid = " + id + " and productid = " + productid :
                "update carts set quantity = " + (await GetProductQuantity(int.Parse(productid)) - 1)
                    + " where userid= " + id + " and productid = " + productid;
            using var command = new MySqlCommand(query, db);
            await command.ExecuteNonQueryAsync();

            await db.CloseAsync();
            return Json(true);
        }

        [Authorize]
        public async Task<IActionResult> CheckOut()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            CartModel cart = await GetCart(userid);
            UserModel user = await GetUser(userid);
            OrderModel order = new OrderModel()
            {
                cart = cart,
                user = user
            };
            return View(order);
        }

        public async Task<UserModel> GetUser(string userid)
        {
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();
            var query = "select * from users where userid = " + userid;
            using var command = new MySqlCommand(query, db);
            using var r = await command.ExecuteReaderAsync();

            UserModel user = new UserModel();
            while (await r.ReadAsync())
            {
                user.id = r.GetInt32(0);
                user.name = r.GetString(1);
                user.fullname = r.GetString(5);
                user.address = r.GetString(7);
                user.phone = r.GetString(8);
            }

            await db.CloseAsync();
            return user;
        }


        public async Task<IActionResult> TaskCheckOut()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var date = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
            int orderid = await CreateOrder(id, date);

            CartModel cart = await GetCart(id);
            foreach (var item in cart.items)
            {
                await InsertProductToOrder(item.id, item.quantity, item.price, orderid);
            }

            await CreateOrderHistory(orderid, int.Parse(id), date, "");

            await DeleteCart();

            return View();
        }

        public async Task<int> CreateOrder(string userid, string date)
        {
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();

            var query = "insert into orders(userid, createdat, updatedat, status, shippingcost, tax, discount) "
                + "values (@userid, @createdat, @updatedat, @status, @shippingcost, @tax, @discount)";
            using var command = new MySqlCommand(query, db);
            command.Parameters.AddWithValue("@userid", userid);
            command.Parameters.AddWithValue("@createdat", date);
            command.Parameters.AddWithValue("@updatedat", date);
            command.Parameters.AddWithValue("@status", 1);
            command.Parameters.AddWithValue("@shippingcost", 0);
            command.Parameters.AddWithValue("@tax", 0);
            command.Parameters.AddWithValue("@discount", 0);
            await command.ExecuteNonQueryAsync();

            query = "select orderid from orders where userid = " + userid + " and createdat = '" + date + "'";
            using var orderid = new MySqlCommand(query, db);
            using var r = await orderid.ExecuteReaderAsync();

            int order = 0;
            while (await r.ReadAsync())
            {
                order = r.GetInt32(0);
            }

            await db.CloseAsync();

            return order;
        }

        public async Task InsertProductToOrder(int itemid, int quantity, decimal price, int orderid)
        {
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();

            var query =
                "insert into orderitems(orderid, productid, quantity, price) " +
                "values (" + orderid + "," + itemid + "," + quantity + "," + price + ")";
            using var command = new MySqlCommand(query, db);
            await command.ExecuteNonQueryAsync();

            await db.CloseAsync();
        }

        public async Task CreateOrderHistory(int orderid, int userid, string date, string note)
        {
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();
            var query =
                "insert into orderhistories(orderid, orderstatusid, userid, changedate, note) values " +
                "(" + orderid + ",1," + userid + ",'" + date + "','" + note + "')";
            using var command = new MySqlCommand(query, db);
            await command.ExecuteNonQueryAsync();

            await db.CloseAsync();
        }

        public async Task DeleteCart()
        {
            MySqlConnection db = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
            await db.OpenAsync();
            var query = "delete from carts where userid = " + User.FindFirstValue(ClaimTypes.NameIdentifier);
            using var command = new MySqlCommand(query, db);
            await command.ExecuteNonQueryAsync();

            await db.CloseAsync();
        }
    }
}
