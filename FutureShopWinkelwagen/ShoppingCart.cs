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

            for (int i = 0; i < 50; i++)
            {
                productList.Items.Add("item " + i);
            }
        }

        public void startScanning()
        {
            RFIDReader reader = RFIDReader.getInstance();
            reader.startReading(this);
        }

        public void updateList()
        {
            productList.Items.Clear();
            priceList.Items.Clear();
            decimal total = 0;
            foreach(KeyValuePair<String, Object> tag in tags){
                Product product = (Product)tag.Value;
                productList.Items.Add(product.name);
                priceList.Items.Add("€" + product.price);
                total += product.price;
            }
            totaalPrijs.Text = "€" + total;
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

        private void import_Click(object sender, EventArgs e)
        {
            importNotification.InitialDuration = Int32.MaxValue;
            importNotification.Text = @"<form>
                  <b>Uw code:</b> <input type=""text"" name=""code"" size=""15"" /><br />
                  <input type=""submit"" style=""float: right;"" />
                </form>";
            importNotification.Visible = true;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            tags.Clear();
            updateList();
        }

        private void importNotification_ResponseSubmitted(object sender, ResponseSubmittedEventArgs e)
        {
            importNotification.Visible = false;
            GroceryList groceryList = API.getInstance().getGroceryListWithId(Convert.ToInt32(e.Response.Substring(6)));
            tags.Clear();
            productList.Items.Clear();
            priceList.Items.Clear();
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