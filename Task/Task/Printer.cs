using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.People;

namespace Task
{
    public class Printer : IPrintable
    {
        public void Print(Candidate person)
            => Console.WriteLine($"Hello, I am {person.Name} {person.LastName} I want to be a {person.Position} ({person.PositionDescription}) with a salary from {person.DesiredSalary}");

        public void Print(Employee person)
            => Console.WriteLine($"Hello, I am {person.Name} {person.LastName}, {person.Position} in {person.Company} ({person.CompanyCountry}, {person.CompanyCity}, {person.CompanyStreet}) and my salary {person.Salary}");
    }
}
