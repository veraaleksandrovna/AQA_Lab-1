using System;
using NLog;

namespace JsonSerialization
{
    public class Order
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Guid Id;

        public Phone Phone;

        public Shop Shop;

        public Order(Phone phone, Shop shop)
        {
            Id = Guid.NewGuid();
            Phone = phone;
            Shop = shop;
            logger.Info($"Order {Phone.Model} with total price {Phone.Price} created!");
        }
    }
}
