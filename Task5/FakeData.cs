using Bogus;

namespace ShopSimulator;

public class FakeData
{
    public IEnumerable<Goods> GenerateGoods(List<Goods> listOfGoods)
    {
        Randomizer.Seed = new Random(123456);

        var wareGenerator = new Faker<Goods>()
            .RuleFor(w => w.Id, (f, w) => f.Commerce.Ean8())
            .RuleFor(w => w.Name, (f, w) => f.Commerce.ProductName())
            .RuleFor(w => w.Category, (f, w) => f.Commerce.Categories(1)[0])
            .RuleFor(w => w.Price, (f, w) => f.Commerce.Price());
        return wareGenerator.Generate(listOfGoods.Count);
    }

    public IEnumerable<User> GenerateUsers(List<User> listOfUsers)
    {
        var customerGenerator = new Faker<User>()
            .RuleFor(c => c.Id, (f, c) => f.Finance.Account())
            .RuleFor(c => c.Name, (f, c) => f.Name.FullName())
            .RuleFor(c => c.Age, (f, c) => f.Person.Random.Int(6, 110))
            .RuleFor(c => c.Order, () => new Order());
        return customerGenerator.Generate(listOfUsers.Count);
    }
}
