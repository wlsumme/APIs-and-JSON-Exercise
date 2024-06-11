using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class RonVSKanyeAPI
    {

        public static void Convo()
        {
            var client = new HttpClient();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Kanye said to Ron:\n{GetKanyeQuote(client)}\nThen Ron said:\n{GetRon(client)}");
            }
        }


            private static string GetKanyeQuote(HttpClient client)
            {
                var jsonText = client.GetStringAsync("http://api.kanye.rest/").Result;


                return JObject.Parse(jsonText).GetValue("quote").ToString();

            }

            private static string GetRon(HttpClient client)
            {
                var jsonText = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;


                var quote = jsonText.Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();

                return quote;

            }
        
    }
}