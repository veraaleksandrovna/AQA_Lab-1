namespace ShopSimulator;

public class User
{
    public string Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public Order Order { get; set; }

    public void SetCustomer(string Id, string name, int age, Order order)
    {
        this.Id = Id;
        Name = name;
        Age = age;
        Order = order;
    }

    public bool Equals(User user)
    {
        return Id == user.Id;
    }

    public void AddGoods(Goods goods)
    {
        Order.Goods.Add(goods);
    }
}
