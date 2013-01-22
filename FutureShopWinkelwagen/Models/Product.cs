using System;

using System.Collections.Generic;
using System.Text;

namespace FutureShopWinkelwagen.Models
{
    class Product
    {
        public String EAN { get; set; }
        public String name { get; set; }
        public int stock { get; set; }
        public decimal price { get; set; }
    }
}
