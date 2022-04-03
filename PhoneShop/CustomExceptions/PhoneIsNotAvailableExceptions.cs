
namespace PhoneShop
{
    public class PhoneIsNotAvailableExceptions : Exception
    {
        public PhoneIsNotAvailableExceptions()
        {
        }
        public PhoneIsNotAvailableExceptions(string message) 
            : base(message)
        {
        }
        public PhoneIsNotAvailableExceptions(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}