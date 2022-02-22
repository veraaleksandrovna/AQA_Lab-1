using ShopSimulator;

public class Program
{
    public static void Main(string[] args)
    {
        var action = new ShopActions();
        var repository = new FakeData();
        var listOfGoods = new List<Goods>();
        for (var i = 0; i < 5; i++)
        {
            var item = new Goods();
            listOfGoods.Add(item);
        }

        var goods = GenerateListOfGoods(repository, listOfGoods, out var orders);

        var users = CreateListOfUsers(repository, orders);

        var menuChoice = "";
        var userChoice = 0;
        do
        {
            Console.WriteLine($"Choose you want to do ({userChoice}):");
            Console.WriteLine("1.View all users");
            Console.WriteLine("2.View users order");
            Console.WriteLine("3. Add new user");
            Console.WriteLine("4.Edit order");
            Console.WriteLine("0.Exit");
            Console.Write("Your choice: ");

            menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                case "1":
                    action.PrintUsers(users);

                    break;

                case "2":
                    action.ViewUsersOrder(users);
                    ;
                    break;
                case "3":

                    action.AddUserConsole(users);

                    break;
                case "4":

                    Console.Write("Add(1) \n Delete (2)");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            action.AddNewGoods(goods, users, userChoice);
                            break;
                        case "2":
                            action.RemoveGods(users, userChoice);
                            break;
                    }

                    break;
                default:

                    Console.WriteLine("Invalid number");
                    break;
            }
        } while (menuChoice != "0");
    }

    private static IEnumerable<Goods> GenerateListOfGoods(FakeData repository, List<Goods> listOfGoods,
        out List<Order> orders)
    {
        var goods = repository.GenerateGoods(listOfGoods);

        var randomNumber = new Random();
        orders = new List<Order>();
        for (var i = 0; i < 5; i++)
        {
            orders.Add(new Order());
            for (var j = 0; j < randomNumber.Next(2, 20); j++)
                orders[i].Goods.Add(goods.ElementAt(randomNumber.Next(goods.Count() - 1)));
        }

        return goods;
    }

    private static IEnumerable<User> CreateListOfUsers(FakeData repository, List<Order> orders)
    {
        var listOfUsers = new List<User>();
        for (var i = 0; i < 5; i++)
        {
            var user = new User();
            listOfUsers.Add(user);
        }

        var users = repository.GenerateUsers(listOfUsers);
        for (var i = 0; i < 5; i++) users.ElementAt(i).Order = orders[i];

        return users;
    }
}
