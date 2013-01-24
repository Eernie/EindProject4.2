﻿using System;

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
using FutureShopWinkelwagen.DjangoModels;

namespace FutureShopWinkelwagen
{
    public partial class ShoppingCart : Form
    {
        public delegate void AddListItem(String tag, String body);
        public AddListItem addTag;
        public Dictionary<String, DjangoGroceryListProduct> groceryListProducts = new Dictionary<String, DjangoGroceryListProduct>();
        public Dictionary<String, Product> scannedProducts = new Dictionary<String, Product>();
        public List<String> scannedTags = new List<String>();

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

        public void updateList()
        {
            productListView.Items.Clear();
            decimal total = 0;
            foreach (KeyValuePair<String, DjangoGroceryListProduct> tag in groceryListProducts)
            {
                DjangoGroceryListProduct djangoProduct = tag.Value;
                Product product = djangoProduct.product.fields;
                int amountScanned = 0;
                if (scannedProducts.ContainsKey(product.EAN))
                {
                    Product scannedProduct = scannedProducts[product.EAN];
                    amountScanned = scannedProduct.amountScanned;
                }
                String[] values = { product.name, amountScanned + "/" + djangoProduct.amount, "€" + product.price * amountScanned };
                ListViewItem item = new ListViewItem(values);
                productListView.Items.Add(item);
                total += product.price * amountScanned;
            }
            foreach (KeyValuePair<String, Product> tag in scannedProducts)
            {
                Product product = tag.Value;
                if(!groceryListProducts.ContainsKey(product.EAN)){
                    String[] values = { product.name, product.amountScanned + "x", "€" + product.price * product.amountScanned };
                    ListViewItem item = new ListViewItem(values);
                    productListView.Items.Add(item);
                    total += product.price * product.amountScanned;
                }
            }
            totaalPrijs.Text = "€" + total;
        }

        public void addTagMethod(String tag, String body)
        {
            if (!scannedTags.Contains(tag))
            {
                Product product = API.getInstance().getProductWithId(Convert.ToInt32(body));
                scannedTags.Add(tag);
                if (scannedProducts.ContainsKey(product.EAN))
                {
                    scannedProducts[product.EAN].amountScanned++;
                }
                else
                {
                    product.amountScanned = 1;
                    scannedProducts.Add(product.EAN, product);
                }
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
            clearListsAndUpdate();
        }

        private void importNotification_ResponseSubmitted(object sender, ResponseSubmittedEventArgs e)
        {
            importNotification.Visible = false;
            DjangoGroceryList[] groceryList = API.getInstance().getGroceryListWithId(Convert.ToInt32(e.Response.Substring(6)));
            groceryListProducts.Clear();
            foreach (DjangoGroceryList djangoGroceryList in groceryList)
            {
                DjangoGroceryListProduct product = djangoGroceryList.fields;
                groceryListProducts.Add(product.product.fields.EAN, product);
            }
            updateList();
        }

        private void clearLists()
        {
            groceryListProducts.Clear();
            scannedProducts.Clear();
            scannedTags.Clear();
        }

        private void clearListsAndUpdate()
        {
            clearLists();
            updateList();
        }
    }
}