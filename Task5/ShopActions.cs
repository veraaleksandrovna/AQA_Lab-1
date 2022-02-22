namespace Task5;

public class ShopActions
{
    public void ViewUsersOrder(IEnumerable<User> users)
    {
        int userChoice;
        Console.Write("Choose user (1-" + 5 + "): ");
        userChoice = Convert.ToInt16(Console.ReadLine());


        var userOrder = users.ElementAt(userChoice - 1).Order.Goods;
        var header = string.Format(" | {0,20} | {1,30} | {2,10} | {3} ", "Category", "Name",
            "Price", "Barcode");
        var line = "\n" + new string('-', header.Length);

        Console.WriteLine(header + line);

        for (var i = 0; i < userOrder.Count(); i++)
        {
            Console.WriteLine("{4,2} | {0,20} | {1,30} | {2,10} | {3} ", userOrder[i].Category,
                userOrder[i].Name,
                userOrder[i].Price, userOrder[i].Id, i + 1);
        }

        Console.WriteLine(line + "\nTotal: " + userOrder.Sum(w => Convert.ToDouble(w.Price)) +
                          line);
    }

    public void PrintUsers(IEnumerable<User> users)
    {
        Console.WriteLine($" {" Name",20} ▐ {"Age",7} ▐ {"ID"}");
        for (var i = 0; i < users.Count(); i++)
        {
            Console.WriteLine("{3,2} ▐ {0,20} ▐ {1,7} ▐ {2}", users.ElementAt(i).Name,
                users.ElementAt(i).Age,
                users.ElementAt(i).Id,
                i + 1);
        }
    }

    public void AddUserConsole(IEnumerable<User> users)
    {
        Console.Write("Passport number: ");
        var userId = Console.ReadLine();

        Console.Write("User name: ");
        var userName = Console.ReadLine();

        Console.Write("User age: ");
        var userAge = Convert.ToInt16(Console.ReadLine());

        var newUser = new User();
        newUser.SetCustomer(userId, userName, userAge, new Order());

        var found = users.Where(u => u.Equals(newUser)).Count() > 0;

        if (found)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Same user exist");

            Console.ResetColor();
        }
        else
        {
            users.Append(newUser);

            Console.WriteLine("User added.");
        }
    }

    public void RemoveGods(IEnumerable<User> users, int userChoice)
    {
        Console.Write("Choose goods in order: ");
        var wareNumberChoice = Convert.ToInt16(Console.ReadLine());
        users.ElementAt(userChoice - 1).Order.Goods.RemoveAt(wareNumberChoice - 1);
        return;
    }

    public void AddNewGoods(IEnumerable<Goods> goods, IEnumerable<User> users, int userChoice)
    {
        var goodsEnumerable = goods as Goods[] ?? goods.ToArray();
        for (var i = 0; i < goodsEnumerable.Count(); i++)
        {
            Console.WriteLine("{4,2} | {0,20} | {1,30} | {2,10} | {3} ",
                goodsEnumerable.ElementAt(i).Category,
                goodsEnumerable.ElementAt(i).Name,
                goodsEnumerable.ElementAt(i).Price, goodsEnumerable.ElementAt(i).Id, i + 1);
        }

        Console.Write("Choose good: ");
        var wareNumberInShop = Convert.ToInt16(Console.ReadLine());

        if (goodsEnumerable.ElementAt(wareNumberInShop - 1).Category == "Alcohol" &&
            users.ElementAt(userChoice - 1).Age < 18)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("OOOPS, Y'RE NOT 18, YET !");

            Console.ResetColor();
        }
        else
        {
            users.ElementAt(userChoice - 1).AddGoods(goodsEnumerable.ElementAt(wareNumberInShop - 1));
        }
        
    }
}
