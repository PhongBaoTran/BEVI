﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class CartModel
    {
        public List<ProductModel> items = new List<ProductModel>();
        public decimal sum { get; set; }
    }
}
