namespace JsonSerialization.Models;

public class Shop
{
    public List<Phone> Phones { get; set; }

    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    /*public string CountPhones()
    {
        var countAndroid = (from phone in Phones where phone.OperationSystemType == "Android" select phone).Count();
        var countIos = (from phone in Phones where phone.OperationSystemType == "IOS" select phone).Count();
        var output = $"Android phones:{countAndroid}, IOS phones: {countIos}";
        return output;
    }
    
    public int PhonesCount()
    {
        int count = 0;
        foreach (var phone in Phones)
        {
            if (phone.IsAvailable)
            {
                count++;
            }
        }

        return count;
    }

    public int CountAndroid()
    {
        int count = 0;
        foreach (var android in Phones)
        {
            if (android.OperationSystemType == "Android" & android.IsAvailable)
            {
                count++;
            }
        }

        return count;
    }

    public int CountIos()
    {
        int count = 0;
        foreach (var ios in Phones)
        {
            if (ios.OperationSystemType == "IOS" & ios.IsAvailable)
            {
                count++;
            }
        }

        return count;
    }*/
}
