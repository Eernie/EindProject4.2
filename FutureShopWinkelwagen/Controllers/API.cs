using System;

using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using FutureShopWinkelwagen.Models;

namespace FutureShopWinkelwagen
{
    class API
    {
        private String url = "http://quiet-cliffs-4239.herokuapp.com/api/";
        private static API api = new API();

        private API() { }

        public static API getInstance()
        {
            return api;
        }

        public Product getProductWithId(int id)
        {
            String url = String.Format(this.url + "{0}/{1}", "product", id);
            String response = callUrl(url);
            DjangoProduct[] dp = JsonConvert.DeserializeObject<DjangoProduct[]>(response);
            return dp[0].fields;
        }

        public GroceryList getGroceryListWithId(int id)
        {
            String url = String.Format(this.url + "{0}/{1}", "grocerylist", id);
            String response = callUrl(url);
            DjangoGroceryList[] dp = JsonConvert.DeserializeObject<DjangoGroceryList[]>(response);
            return dp[0].fields;
        }

        public String callUrl(String url)
        {
            WebRequest request = WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd();
        }
    }
}
