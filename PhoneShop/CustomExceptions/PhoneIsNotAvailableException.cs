
namespace PhoneShop
{
    public class PhoneIsNotAvailableException : Exception
    {
        public PhoneIsNotAvailableException()
        {
        }
        public PhoneIsNotAvailableException(string message) 
            : base(message)
        {
        }
        public PhoneIsNotAvailableException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
