using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class OrderModel
    {
        public CartModel cart = new CartModel();
        public UserModel user = new UserModel();
    }
}
