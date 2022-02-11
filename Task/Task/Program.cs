using System;
using System.Collections.Generic;
using Task.People;

namespace Task
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var listOfCandidate = GetCandidates();
            var listOfEmployee = GetEmployees();

            var printer = new Printer();

            foreach (var item in listOfCandidate)
            {
                printer.Print(item);
            }

            foreach (var item in listOfEmployee)
            {
                printer.Print(item);
            }
        }

        private static List<Candidate> GetCandidates()
        {
            var rand = new Random();
            var id = 0;
            var listOfCandidate = new List<Candidate>();

            for (var i = 0; i < rand.Next(1, 3); i++)
            {
                Console.WriteLine("Enter data about candidate");
                Console.Write("Enter name: ");
                var name = Console.ReadLine();
                Console.Write("Enter last name: ");
                var lastName = Console.ReadLine();
                Console.Write("Enter position: ");
                var position = Console.ReadLine();
                Console.Write("Enter position description: ");
                var description = Console.ReadLine();
                Console.Write("Enter desired salary: ");
                var salary = int.Parse(Console.ReadLine());
                Console.WriteLine();

                var candidate = new Candidate()
                {
                    Id = id++,
                    Name = name,
                    LastName = lastName,
                    Position = position,
                    PositionDescription = description,
                    DesiredSalary = salary
                };

                listOfCandidate.Add(candidate);
            }

            return listOfCandidate;
        }

        private static List<Employee> GetEmployees()
        {
            var rand = new Random();
            var id = 0;
            var listOfEmployee = new List<Employee>();

            for (var i = 0; i < rand.Next(1, 3); i++)
            {
                Console.WriteLine("Enter data about employee");
                Console.Write("Enter name: ");
                var name = Console.ReadLine();
                Console.Write("Enter last name: ");
                var lastName = Console.ReadLine();
                Console.Write("Enter position: ");
                var position = Console.ReadLine();
                Console.Write("Enter desired salary: ");
                var salary = int.Parse(Console.ReadLine());
                Console.Write("Enter company: ");
                var company = Console.ReadLine();
                Console.Write("Enter company country: ");
                var country = Console.ReadLine();
                Console.Write("Enter position city: ");
                var city = Console.ReadLine();
                Console.Write("Enter position street: ");
                var street = Console.ReadLine();
                Console.WriteLine();

                var employee = new Employee()
                {
                    Id = id++,
                    Name = name,
                    LastName = lastName,
                    Position = position,
                    Salary = salary,
                    Company = company,
                    CompanyCountry = country,
                    CompanyCity = city,
                    CompanyStreet = street,
                };

                listOfEmployee.Add(employee);
            }

            return listOfEmployee;
        }
    }
}
