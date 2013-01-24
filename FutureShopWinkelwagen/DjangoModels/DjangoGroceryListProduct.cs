using System;

using System.Collections.Generic;
using System.Text;
using FutureShopWinkelwagen.Models;

namespace FutureShopWinkelwagen.DjangoModels
{
    public class DjangoGroceryListProduct
    {
        public int grocerylist { get; set; }
        public DjangoProduct product { get; set; }
        public int amount { get; set; }
    }
}
