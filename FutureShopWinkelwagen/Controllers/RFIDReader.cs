﻿using System;

using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace FutureShopWinkelwagen
{
    class RFIDReader
    {
        private static RFIDReader reader = new RFIDReader();
        private RFIDReader(){}

        public static RFIDReader getInstance()
        {
            return reader;
        }

        public Boolean isAvailable()
        {
            return C1Lib.C1.NET_C1_open_comm() == 1 || C1Lib.C1.NET_C1_enable() == 1;
        }

        public void startReading(ShoppingCart shoppingCart)
        {
            if(isAvailable()){
                while (true)
                {
                    while (C1Lib.ISO_15693.NET_get_15693(0) == 0){}
                    if (C1Lib.ISO_15693.NET_read_multi_15693(0, C1Lib.ISO_15693.tag.blocks) == 1)
                    {
                        String tag = readTag();
                        String body = readBody();
                        shoppingCart.Invoke(shoppingCart.addTag, new Object[] { tag, body });
                    }
                }
            }
        }

        public String readTag()
        {
            String tag_id = "";
            for (int i = 0; i < C1Lib.ISO_15693.tag.id_length; i++)
            {
                tag_id = tag_id + C1Lib.util.hex_value(C1Lib.ISO_15693.tag.tag_id[i]);
            }
            return tag_id;
        }

        public String readBody()
        {
            return C1Lib.util.to_str(C1Lib.ISO_15693.tag.read_buff, 256);
        }
    }
}
