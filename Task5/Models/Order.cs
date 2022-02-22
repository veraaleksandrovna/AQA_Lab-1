namespace ShopSimulator;

public class Order
{
    public Order()
    {
        Goods = new List<Goods>();
    }

    public List<Goods> Goods { get; }
}
