using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string fullname { get; set; }
        public bool gender { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
    }
}
