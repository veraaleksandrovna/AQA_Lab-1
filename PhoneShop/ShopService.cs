using Microsoft.Extensions.Logging;

namespace PhoneShop
{
    public class ShopService
    {
        public Shop[] Shops { get; set; }
        
        private int _countPhones;
        private int _countShops;
        private static ILoggerFactory loggerFactory = LoggerFactory.Create(config => { config.AddConsole(); });
        private ILogger<ShopService> logger = loggerFactory.CreateLogger<ShopService>();

        public void DispalyIfAvaliable()
        {
            var iosCount = 0;
            var androidCount = 0;
            foreach (var shop in Shops)
            {
                logger.LogInformation(
                    $"[Id] [Name]\n      {shop.Id} {shop.Name}\n      [Description]\n      {shop.Description}\n      [Amount of phones in stock]");
                foreach (var phone in shop.Phones)
                {
                    switch (phone.OperationSystemType)
                    {
                        case OperationSystemType.IOS:
                            iosCount++;
                            break;
                        case OperationSystemType.Android:
                            androidCount++;
                            break;
                    }
                }

                logger.LogInformation($"{iosCount} IOS based phones are avaliable");
                logger.LogInformation($"{androidCount} Android based phones are avaliable");
                iosCount = 0;
                androidCount = 0;
            }
        }

        public void ChoosePhoneToBuy()
        {
            List<Phone> purchase = new List<Phone>();
            logger.LogWarning("Which mobile phone do you want to buy?");
            CheckAvailability(purchase);
            if (purchase.Count == 0 && _countPhones < 2)
            {
                logger.LogInformation("This mobile phone is not found");
                ChoosePhoneToBuy();
            }

            if (purchase.Count > 0)
            {
                logger.LogInformation("Your request is satisfied.");
                logger.LogInformation(
                    $"[Model]\n  {purchase[0].Model}\n  [Operating system]\n  {purchase[0].OperationSystemType}\n  " +
                    $"  [Market Launch]\n   {purchase[0].MarketLaunchDate}\n   [Price]\n  ${purchase[0].Price}");
                if (purchase.Count == 1)
                {
                    logger.LogInformation(
                        $"You can purchase it in the {Shops[purchase[0].ShopId - 1].Name}\n      {Shops[purchase[0].ShopId - 1].Description}");
                    WantToBuyShop(purchase);
                }
                else if (purchase.Count > 1)
                {
                    logger.LogInformation("You can purchase it in the following shops:");
                    for (int i = 0; i <= purchase.Count - 1; i++)
                    {
                        logger.LogInformation(
                            $"{Shops[purchase[i].ShopId - 1].Name}\n      {Shops[purchase[i].ShopId - 1].Description}");
                    }

                    WantToBuyShop(purchase);
                }
            }
        }

        private void CheckAvailability(List<Phone> purchase)
        {
            var phoneModel = Console.ReadLine();
            foreach (var shop in Shops)
            {
                foreach (var phone in shop.Phones)
                {
                    if (phoneModel == phone.Model)
                    {
                        try
                        {
                            if (phone.IsAvailable == true)
                            {
                                purchase.Add(phone);
                            }
                            else
                            {
                                _countPhones++;
                                if (_countPhones < 2)
                                {
                                    logger.LogInformation("This mobile phone is out of stock. Choose another model.");
                                    ChoosePhoneToBuy();
                                }
                                else
                                {
                                    throw new PhoneIsNotAvailableException();
                                }
                            }
                        }
                        catch (PhoneIsNotAvailableException)
                        {
                            logger.LogError("This mobile phone is out of stock.");
                        }
                    }
                }
            }
        }

        private void WantToBuyShop(List<Phone> purchase)
        {
            string shop;
            bool isFound = false;
            logger.LogWarning($"In which store do you want to buy the mobile phone {purchase[0].Model}?");
            shop = Console.ReadLine();
            for (int i = 0; i <= purchase.Count - 1; i++)
            {
                if (shop == Shops[purchase[i].ShopId - 1].Name)
                {
                    logger.LogInformation(
                        $"Order for {purchase[i].Model} ({purchase[i].OperationSystemType}), price ${purchase[i].Price}, market launch date {purchase[i].MarketLaunchDate}, in shop {Shops[purchase[i].ShopId - 1].Name} has been successfully placed.");
                    isFound = true;
                }
            }

            if (isFound == false)
            {
                try
                {
                    _countShops++;
                    if (_countShops < 2)
                    {
                        logger.LogInformation("This shop is not found. Choose another shop.");
                        WantToBuyShop(purchase);
                    }
                    else
                    {
                        throw new ShopNotFoundException();
                    }
                }
                catch (ShopNotFoundException)
                {
                    logger.LogError("This shop is not found.");
                }
            }
        }
    }
}
