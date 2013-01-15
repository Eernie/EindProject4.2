using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1Lib;

namespace FutureShopWinkelwagen
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void firstTest()
        {
            if (C1Lib.C1.NET_C1_open_comm() != 1 || C1Lib.C1.NET_C1_enable() != 1)
            {
                display.Text = "RFID Card Not Inserted.";
                return;
            }
            display.Text = "RFID card is inserted";

            int num = 1, j = 0;
            string text;
            while (C1Lib.ISO_15693.NET_get_15693(0) == 0)
            {
                text = "Sensing For Tag";
                for (int i = 0; i < num % 5; i++) text = text + ".";
                num++;
                display.Text = text;
                if (j++ == 30)
                {
                    display.Text = "Tag Not Found.";

                }
            }

            bool failed = false;
            display.Text = "Reading Tag";

            if (C1Lib.ISO_15693.NET_read_multi_15693(0, C1Lib.ISO_15693.tag.blocks) != 1) { failed = true; }

            string tag_id = "";
            for (int i = 0; i < C1Lib.ISO_15693.tag.id_length; i++) tag_id = tag_id + C1Lib.util.hex_value(C1Lib.ISO_15693.tag.tag_id[i]);

            String display_text = C1Lib.util.to_str(C1Lib.ISO_15693.tag.read_buff, 256);

            display.Text = display_text;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.firstTest();
        }
    }
}