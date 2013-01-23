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
            String url = String.Format(this.url + "{0}/{1}{2}", "product", id, ".json");
            String response = callUrl(url);
            DjangoProduct[] dp = JsonConvert.DeserializeObject<DjangoProduct[]>(response);
            return dp[0].fields;
        }

        public GroceryList getGroceryListWithId(int id)
        {
            String url = String.Format(this.url + "{0}/{1}{2}", "grocerylist", id, ".json");
            String response = callUrl(url);
            DjangoGroceryList[] dp = JsonConvert.DeserializeObject<DjangoGroceryList[]>(response);
            return dp[0].fields;
        }

        public String callUrl(String url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            WebResponse response = request.GetResponse();
            using(var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
