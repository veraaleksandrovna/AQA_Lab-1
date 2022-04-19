using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace PhoneShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"JSonFiles\appsettings.json");
            string json;
            ILoggerFactory loggerFactory = LoggerFactory.Create(config =>
            {
                config.AddConsole();
            });
            ILogger<ShopService> logger = loggerFactory.CreateLogger<ShopService>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    json = sr.ReadToEnd();
                }
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                var shops = JsonConvert.DeserializeObject<ShopService>(json, settings);
                shops.DispalyIfAvaliable();
                shops.ChoosePhoneToBuy();
            }
            catch (FileNotFoundException)
            {
                logger.LogError("The file or directory cannot be found.");
            }
           
        }
    }
}
