using JsonSerialization.Models;
using SimpleLogger;
using SimpleLogger.Logging.Handlers;

namespace JsonSerialization;

public class Program
{
    private const string FileName = "appsettings.json";

    private const string ChequeFile = "info.json";

    public static void Main(string[] args)
    {
        Logger.LoggerHandlerManager.AddHandler(new ConsoleLoggerHandler());
        Logger.DefaultLevel = Logger.Level.Fine;

        var shops = JsonHandler.Deserialzation<Shops>(FileName) as Shops;

        var menu = new WorkWithShop(shops.ListShops);

        menu.ShowAllShops();
        var phone = menu.ProcessUserInput();
        menu.CheckingAvailability(phone, ChequeFile);

        /* var shops = JsonHandler.Deserialization<Shops>(FileName) as Shops;
         var shopsHandler = new WorkWithShop(shops.ListShops);
         var phones = new Phone();
         
         Logger.Log("Choose menu item");
         Logger.Log("1. Show all phones");
         Logger.Log("2.Count phones");
         Logger.Log("3.Choose phone");

         var choice = Console.ReadLine();
         switch (choice)
         {
             case  "1":
                 shopsHeandler.WorkWithPhones(phones);
                 break;
             case "2":
                 shopsHeandler.WorkWithShops();
                 break;
             case "3":
                 shopsHeandler.CheckPhone(phones,fileName);
                 break;
         }*/

        Console.ReadKey();
    }
}
