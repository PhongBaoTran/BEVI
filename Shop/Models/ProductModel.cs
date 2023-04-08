using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ProductModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public decimal lastprice { get; set; }

        public List<string> img = new List<string>();
        public int categoryid { get; set; }
        public int quantity { get; set; }
    }
}
