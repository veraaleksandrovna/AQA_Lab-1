using JsonSerialization.CustomExceptions;
using JsonSerialization.Models;
using SimpleLogger;

namespace JsonSerialization;

public class WorkWithShop
{
    private const string Ios = "IOS";

    private const string Android = "Android";

    private readonly List<Shop> shops;

    public WorkWithShop(List<Shop> shops)
    {
        this.shops = shops;
    }

    public Phone ProcessUserInput()
    {
        string phoneModel;
        do
        {
            try
            {
                Logger.Log("Please Enter phone model: ");
                phoneModel = Console.ReadLine();
                if (AvailablePhones(phoneModel, out var phone)) return phone;
            }
            catch (PhoneNotFoundException ex)
            {
                Logger.Log(ex);
            }
        } while (true);
    }

    private bool AvailablePhones(string phoneModel, out Phone foundPhone)
    {
        var availableShops = shops.FindAll(shop => shop.Phones!.Exists(item => item!.Model.Equals(phoneModel)));

        if (availableShops.Count == 0) throw new PhoneNotFoundException("Phone Not Found.");

        Phone checkPhone = null;
        availableShops.ForEach(shop =>
        {
            PrintOneShop(shop);
            checkPhone = shop.Phones!.First(smartphone => smartphone!.Model.Equals(phoneModel));
            PrintPhoneInfo(checkPhone);
        });

        if (checkPhone!.IsAvailable)
        {
            foundPhone = checkPhone;
            return true;
        }

        foundPhone = null;
        Logger.Log("Phone is not available in stock.");
        return false;
    }

    private static int CountPhones(string os, IEnumerable<Phone> phones)
    {
        var availablePhones = phones!
            .Where(phone => phone.OperationSystemType.Equals(os))
            .Where(phone => phone.IsAvailable);
        return availablePhones.Count();
    }

    public void ShowAllShops()
    {
        shops.ForEach(shop =>
        {
            PrintOneShop(shop);
            shop.Phones!.ForEach(PrintPhoneInfo);
            var iosCount = CountPhones(Ios, shop.Phones);
            var androidCount = CountPhones(Android, shop.Phones);
            Logger.Log($"\n IOS phones: {iosCount} \n Android phones: {androidCount}");
        });
    }

    private static void PrintOneShop(Shop shop)
    {
        Logger.Log($"{shop.Id} || {shop.Name} || {shop.Description}");
    }

    private static void PrintPhoneInfo(Phone phone)
    {
        Logger.Log($"{phone!.Model} || {phone.OperationSystemType} || {phone.MarketLaunchDate}" +
                   $" || {phone.Price} || Available: {phone.IsAvailable}");
    }

    public void CheckingAvailability(Phone phone, string fileName)
    {
        Shop chosenShop;
        string shopName = null;
        do
        {
            Logger.Log("Enter shop you want to buy from: ");
            try
            {
                chosenShop = InputShop(shopName);
                Logger.Log($"Order for shop {chosenShop}: {phone!.Model} for {phone.Price} USD successfully created!");
                JsonHandler.Serialization(fileName, phone);
                return;
            }
            catch (ShopNotFoundException ex)
            {
                Logger.Log(ex);
            }
        } while (true);
    }

    private Shop InputShop(string shopName)
    {
        Shop chooseShop;
        shopName = Console.ReadLine();
        chooseShop = shops.FirstOrDefault(shop => shop.Name.Equals(shopName));
        if (chooseShop == null) throw new ShopNotFoundException("Store not found.");

        return chooseShop;
    }
}
