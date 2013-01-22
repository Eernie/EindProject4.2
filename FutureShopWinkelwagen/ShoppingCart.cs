using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using C1Lib;

namespace FutureShopWinkelwagen
{
    public partial class ShoppingCart : Form, Observer
    {
        public ShoppingCart()
        {
            InitializeComponent();
            Thread readerThread = new Thread(startScanning);
            readerThread.Start();
        }

        public void startScanning()
        {
            RFIDReader reader = RFIDReader.getInstance();
            reader.addObserver(this);
            reader.startReading();
        }


        private void button1_Click(object sender, EventArgs e)
        {
        }

        public void addToList(String item)
        {
            ListViewItem i = new ListViewItem(item);

            listView1.Items.Add(i);
        }

        public void update(String tag, String body)
        {
            this.label1.Text = tag;
            this.label2.Text = body;
        }
    }
}