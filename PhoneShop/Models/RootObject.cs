using Microsoft.Extensions.Logging;
using PhoneShop.CustomExceptions;

namespace PhoneShop.Models;

public class RootObject
{
    public Shop[] Shops { get; }
    
    private int countPhones;
    private int countShops;
    private static ILoggerFactory loggerFactory = LoggerFactory.Create(config => { config.AddConsole(); });
    private ILogger<RootObject> logger = loggerFactory.CreateLogger<RootObject>();

    public void DispalyIfAvaliable()
    {
        var iosCount = 0;
        var androidCount = 0;
        for (var i = 0; i < Shops.Length; i++)
        {
            logger.LogInformation(
                $"[Id] [Name]\n {Shops[i].Id} {Shops[i].Name}\n [Description]\n" +
                $" {Shops[i].Description}\n [Amount of phones in stock]")
            for (var j = 0; j < Shops[i].Phones.Length; j++)
                if (Shops[i].Phones[j].OperationSystemType == "IOS")
                    iosCount++;
                else if (Shops[i].Phones[j].OperationSystemType == "Android") androidCount++;

            logger.LogInformation($"{iosCount} IOS based phones are avaliable");
            logger.LogInformation($"{androidCount} Android based phones are avaliable");
            iosCount = 0;
            androidCount = 0;
        }
    }

    public void WantToBuyPhone()
    {
        string phoneModel;
        var purchase = new List<Phone>();
        logger.LogWarning("Which mobile phone do you want to buy?");
        phoneModel = Console.ReadLine();
        for (var i = 0; i < Shops.Length; i++)
        for (var j = 0; j < Shops[i].Phones.Length; j++)
            if (phoneModel == Shops[i].Phones[j].Model)
                try
                {
                    if (Shops[i].Phones[j].IsAvailable == true)
                    {
                        purchase.Add(Shops[i].Phones[j]);
                    }
                    else
                    {
                        countPhones++;
                        if (countPhones < 2)
                        {
                            logger.LogInformation("This mobile phone is out of stock. Choose another model.");
                            WantToBuyPhone();
                        }
                        else
                        {
                            throw new IsNotAvailable();
                        }
                    }
                }
                catch (IsNotAvailable)
                {
                    logger.LogError("This mobile phone is out of stock.");
                }

        if (purchase.Count == 0 && countPhones < 2)
        {
            logger.LogInformation("This mobile phone is not found");
            WantToBuyPhone();
        }

        if (purchase.Count > 0)
        {
            logger.LogInformation("Your request is satisfied.");
            logger.LogInformation(
                $"[Model]\n  {purchase[0].Model}\n    [Operating system]\n      {purchase[0].OperationSystemType}\n      [Market Launch]\n      {purchase[0].MarketLaunchDate}\n      [Price]\n      ${purchase[0].Price}");
            if (purchase.Count == 1)
            {
                logger.LogInformation(
                    $"You can purchase it in the {Shops[purchase[0].ShopId - 1].Name}\n      {Shops[purchase[0].ShopId - 1].Description}");
                WantToBuyShop(purchase);
            }
            else if (purchase.Count > 1)
            {
                logger.LogInformation("You can purchase it in the following shops:");
                for (var i = 0; i <= purchase.Count - 1; i++)
                    logger.LogInformation(
                        $"{Shops[purchase[i].ShopId - 1].Name}\n      {Shops[purchase[i].ShopId - 1].Description}");

                WantToBuyShop(purchase);
            }
        }
    }

    private void WantToBuyShop(List<Phone> purchase)
    {
        string shop;
        var isFound = false;
        logger.LogWarning($"In which store do you want to buy the mobile phone {purchase[0].Model}?");
        shop = Console.ReadLine();
        for (var i = 0; i <= purchase.Count - 1; i++)
            if (shop == Shops[purchase[i].ShopId - 1].Name)
            {
                logger.LogInformation(
                    $"Order for {purchase[i].Model} ({purchase[i].OperationSystemType}), price ${purchase[i].Price}, market launch date {purchase[i].MarketLaunchDate}, in shop {Shops[purchase[i].ShopId - 1].Name} has been successfully placed.");
                isFound = true;
            }

        if (isFound == false)
            try
            {
                countShops++;
                if (countShops < 2)
                {
                    logger.LogInformation("This shop is not found. Choose another shop.");
                    WantToBuyShop(purchase);
                }
                else
                {
                    throw new NotFoundException();
                }
            }
            catch (NotFoundException)
            {
                logger.LogError("This shop is not found.");
            }
    }
}
