using System;
using System.Collections.Generic;
using JsonSerialization.Exceptions;
using NLog;

namespace JsonSerialization
{
    [Serializable]
    public class JsonShops
    {
        public class AllShops
        {
            private static Logger logger = LogManager.GetCurrentClassLogger();

            public List<Shop> Shops { get; set; }


            public string ShopByNumber(int shopId)
            {
                var shop = Shops.Find(s => s.Id == shopId);
                return shop.Name;
            }

            public Shop ChooseShop(string phoneChoice)
            {
                string shopChoice;

                do
                {
                    logger.Info($"Choose shop {phoneChoice}?");
                    shopChoice = Console.ReadLine();
                    var foundShop = Shops.Find(s => s.Name == shopChoice);
                    if (foundShop != null)
                    {
                        return foundShop;
                    }

                    logger.Info("Shop isn't exsist");
                    try
                    {
                        throw new StoreNotFoundException(message: "Enter shop again:");
                    }
                    catch (Exception e)
                    {
                        logger.Info(e);
                    }
                } while (true);
            }

            public string FindPhone()
            {
                string phoneChoice;
                var found = new List<Phone>();
                var phone = new Phone();
                do
                {
                    try
                    {
                        logger.Info("Chose phone, input model: ");
                        phoneChoice = Console.ReadLine();

                        foreach (var shop in Shops)
                        {
                            phone = shop.Phones.Find(p => p.Model == phoneChoice);
                            if (phone != null)
                            {
                                found.Add(phone);
                            }
                        }

                        Program.foundPhones = found;

                        if (Program.foundPhones.Count == 0)
                        {
                            logger.Info("No such phone");
                        }

                        var inStorage = Program.foundPhones.Find(p => p.IsAvailable);

                        if (inStorage == null)
                        {
                            logger.Info("No available phone.");
                            throw new PhoneNotFoundException("Input model agaim.");
                        }
                        else
                        {
                            var successfulRequest = Program.foundPhones.FindAll(p => p.IsAvailable);
                            successfulRequest.ForEach(p => p.Report());

                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        logger.Info(e.Message);
                    }
                } while (true);

                return phoneChoice;
            }
        }
    }
}
