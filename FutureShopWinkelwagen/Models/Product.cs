using System;

using System.Text;

namespace FutureShopWinkelwagen.Models
{
    public class Product
    {
        public String EAN { get; set; }
        public String name { get; set; }
        public int stock { get; set; }
        public decimal price { get; set; }
        public int amountScanned { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Product)
            {
                return ((Product)obj).EAN == this.EAN;
            }
            else
            {
                return false;
            }
        }
    }
}
