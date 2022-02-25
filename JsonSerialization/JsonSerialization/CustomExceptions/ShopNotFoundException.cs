namespace JsonSerialization.CustomExceptions;

public class ShopNotFoundException : Exception
{
    public ShopNotFoundException()
    {
    }

    public ShopNotFoundException(string message) : base(message)
    {
    }
}
