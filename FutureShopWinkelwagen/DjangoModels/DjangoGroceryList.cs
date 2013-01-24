using System;

using System.Collections.Generic;
using System.Text;

namespace FutureShopWinkelwagen.DjangoModels
{
    class DjangoGroceryList
    {
        public int pk { get; set; }
        public String model { get; set; }
        public DjangoGroceryListProduct fields { get; set; }
    }
}
