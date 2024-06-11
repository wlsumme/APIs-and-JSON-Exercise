using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        //https://api.openweathermap.org/data/2.5/weather?zip=35209&appid={apiKey}&units=imperial

            public static void GetTemp()
        {
            var appSettingsText = File.ReadAllText("appsettings.json");

            var apiKey = JObject.Parse(appSettingsText).GetValue("key").ToString();

            Console.WriteLine("Enter your ZIP and get the real feel temp outside.");

            var zip = Console.ReadLine();

            var url = $"https://api.openweathermap.org/data/2.5/weather?zip={zip}&appid={apiKey}&units=imperial";

            var client = new HttpClient();

            var jsonText = client.GetStringAsync(url).Result;

            var weatherObj = JObject.Parse(jsonText);

            Console.WriteLine($"Real feel is {weatherObj["main"]["feels_like"]}");
        }


    }
}
