using System;

namespace bot
{
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=====ДОБРО ПОЖАЛОВАТЬ В ЧАТ-БОТ=====");
        Console.WriteLine("Введите ваше имя: ");
        string FirstName = Console.ReadLine();
        Console.WriteLine("Введите вашу фамилию");
        string LastName = Console.ReadLine();
        
            Console.WriteLine("Введите желаемую дату приёма в формате дд/мм/гггг");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            if (date > DateTime.Now)
                Console.WriteLine(
                    $"{UppercaseFirst(LastName)} {UppercaseFirst(FirstName)}, вы записаны на приём {date.Date}");
            else
                Console.WriteLine("Дата введена неверно");
       
    }

    static string UppercaseFirst(string s)
{
if (string.IsNullOrEmpty(s))
{
throw new ArgumentNullException();
}
return char.ToUpper(s[0]) + s.Substring(1);
}
}
}