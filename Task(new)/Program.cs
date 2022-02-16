using Bogus;
using static Task.FakeData;

namespace Task;

public class Program
{
    public static void Main(string[] args)
    {
        Faker<Candidate> generateCandidate = GenerateCandidates();
        List<Candidate> candidates = generateCandidate.Generate(5);
        Faker<Employee> generateEmployee = GenerateEmployies();
        List<Employee> employees = generateEmployee.Generate(5);
        PrintCandidate(candidates);
        PrintEmployee(employees);
        Console.ReadKey();
    }

    private static void PrintCandidate(List<Candidate> candidates)
    {
        foreach (var candidate in candidates)
        {
            Console.WriteLine($"Hello, I am {candidate.Name} {candidate.LastName} I want to be a " +
                              $"{candidate.Position} ({candidate.PositionDescription}) with a salary from {candidate.DesiredSalary}$");
        }
    }

    private static void PrintEmployee(List<Employee> employees)
    {
        foreach (var employee in employees)
        {
            Console.WriteLine(
                $"Hello, I am {employee.Name} {employee.LastName}, I'm {employee.Position} in {employee.Company} " +
                $"({employee.CompanyCountry}, {employee.CompanyCity}, {employee.CompanyStreet}) and my salary {employee.Salary}$ ");
        }
    }
}
