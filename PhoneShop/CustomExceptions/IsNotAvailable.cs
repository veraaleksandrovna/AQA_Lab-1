namespace PhoneShop.CustomExceptions;

public class IsNotAvailable : Exception
{
    public IsNotAvailable()
    {
    }

    public IsNotAvailable(string message)
        : base(message)
    {
    }

    public IsNotAvailable(string message, Exception inner)
        : base(message, inner)
    {
    }
}
