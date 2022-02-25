namespace JsonSerialization.CustomExceptions;

[Serializable]
public class PhoneNotFoundException : Exception
{
    public PhoneNotFoundException()
    {
    }

    public PhoneNotFoundException(string message) : base(message)
    {
    }
}
