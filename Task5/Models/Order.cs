namespace Task5;

public class Order
{
    public List<Goods> Goods { get; set; }

    public Order()
    {
        Goods = new List<Goods>();
    }
}
