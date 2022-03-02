using System.Collections.Generic;
using System.Linq;
using NLog;
namespace JsonSerialization;

public class Shop
{
    private static Logger logger = LogManager.GetCurrentClassLogger();

    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public List<Phone> Phones { get; set; }

    public int CountPhonesWithOsType(string osType)
    {
        var foundPhones = Phones.FindAll(p => p.OperationSystemType == osType && p.IsAvailable);
        var numberOfPhones = foundPhones.Count();

        return numberOfPhones;
    }

    public void Report() 
    {
        logger.Info(
            "\nShopId №{0} {1} - {2}.\nIOS ammount: {3}\nAndroid ammount: {4}\n",
            Id, Name, Description, CountPhonesWithOsType("IOS"), CountPhonesWithOsType("Android"));
    }
}