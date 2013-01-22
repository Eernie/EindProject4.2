using System;

using System.Collections.Generic;
using System.Text;

namespace FutureShopWinkelwagen.Models
{
    class GroceryList
    {
        public DjangoProduct[] products { get; set; }
        public String created_at { get; set; }
        public String update_at { get; set; }
    }
}
