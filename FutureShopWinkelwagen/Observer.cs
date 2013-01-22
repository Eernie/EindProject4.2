using System;
using System.Collections.Generic;
using System.Text;

namespace FutureShopWinkelwagen
{
    interface Observer
    {
        void update(String tag, String body);
    }
}
