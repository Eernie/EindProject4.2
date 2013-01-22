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
using Microsoft.WindowsCE.Forms;
using FutureShopWinkelwagen.Models;

namespace FutureShopWinkelwagen
{
    public partial class ShoppingCart : Form
    {
        public delegate void AddListItem(String tag, String body);
        public AddListItem addTag;
        public Dictionary<String, Object> tags = new Dictionary<string, Object>();

        public ShoppingCart()
        {
            InitializeComponent();
            addTag = new AddListItem(addTagMethod);
            Thread readerThread = new Thread(startScanning);
            readerThread.Start();
        }

        public void startScanning()
        {
            RFIDReader reader = RFIDReader.getInstance();
            reader.startReading(this);
        }


        private void button1_Click(object sender, EventArgs e)
        {
        }

        public void updateList()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            decimal total = 0;
            foreach(KeyValuePair<String, Object> tag in tags){
                Product product = (Product)tag.Value;
                listBox1.Items.Add(product.name);
                listBox2.Items.Add("€" + product.price);
                total += product.price;
            }
            label1.Text = "€" + total;
        }

        public void addTagMethod(String tag, String body)
        {
            if (!tags.ContainsKey(tag))
            {
                Product product = API.getInstance().getProductWithId(Convert.ToInt32(body));
                tags.Add(tag, product);
                updateList();
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            ImportNotification.InitialDuration = Int32.MaxValue;
            ImportNotification.Text = @"<form>
                  <b>Uw code:</b> <input type=""text"" name=""code"" size=""15"" /><br />
                  <input type=""submit"" style=""float: right;"" />
                </form>";
            ImportNotification.Visible = true;
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
        }

        private void notification1_ResponseSubmitted(object sender, ResponseSubmittedEventArgs e)
        {
            ImportNotification.Visible = false;
            GroceryList groceryList = API.getInstance().getGroceryListWithId(Convert.ToInt32(e.Response.Substring(6)));
            tags.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            int i = 0;
            foreach(DjangoProduct djangoProduct in groceryList.products){
                Product product = djangoProduct.fields;
                tags.Add("" + i, product);
                i++;
            }
            updateList();
        }
    }
}