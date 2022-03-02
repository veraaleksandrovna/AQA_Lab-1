using System;

namespace JsonSerialization.Exceptions;


public class StoreNotFoundException : Exception
{
    public StoreNotFoundException()
    {
    }

    public StoreNotFoundException(string message) : base(message)
    {
    }

    public StoreNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}
