using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using PhoneShop.Models;

namespace PhoneShop;

internal class Program
{
    private static void Main(string[] args)
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"JSonFiles\appsettings.json");
        string json;
        var loggerFactory = LoggerFactory.Create(config => { config.AddConsole(); });
        var logger = loggerFactory.CreateLogger<ShopService>();
        
        try
        {
            using (var sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            
            var shops = JsonConvert.DeserializeObject<ShopService>(json, settings);
            shops.DispalyIfAvaliable();
            shops.WantToBuyPhone();
        }
        catch (FileNotFoundException)
        {
            logger.LogError("The file or directory cannot be found.");
        }
        catch (DirectoryNotFoundException)
        {
            logger.LogError("The file or directory cannot be found.");
        }
        catch (DriveNotFoundException)
        {
            logger.LogError("The drive specified in 'path' is invalid.");
        }
        catch (PathTooLongException)
        {
            logger.LogError("'path' exceeds the maxium supported path length.");
        }
        catch (UnauthorizedAccessException)
        {
            logger.LogError("You do not have permission to create this file.");
        }
        catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
        {
            logger.LogError("There is a sharing violation.");
        }
        catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
        {
            logger.LogError("The file already exists.");
        }
        catch (IOException e)
        {
            logger.LogError($"An exception occurred:\nError code: " +
                            $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
        }
    }
}
