﻿using System;
using System.Data;

namespace ConsoleApp3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=====ДОБРО ПОЖАЛОВАТЬ В ЧАТ-БОТ=====");
            Console.WriteLine("Введите ваше имя: ");
            var firstName = Console.ReadLine();
            Console.WriteLine("Введите вашу фамилию");
            var lastName = Console.ReadLine();
            Console.WriteLine("Введите желаемую дату приёма в формате дд/мм/гггг");
            var date = Convert.ToDateTime(Console.ReadLine());
            DateHandler(date);
            Console.WriteLine(
                $"{UppercaseFirst(lastName)} {UppercaseFirst(firstName)}, вы записаны на приём {date.Date}");
        }

        private static void DateHandler(DateTime date)
        {
            if (date > DateTime.Now)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Дата введена неверно");
            }
        }

        private static string UppercaseFirst(string nameOrSurname)
        {
            return char.ToUpper(nameOrSurname[0]) + nameOrSurname.Substring(1);
        }
    }
}
