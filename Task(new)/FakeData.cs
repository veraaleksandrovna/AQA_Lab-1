using Bogus;

namespace Task;

public class FakeData
{
    public static Faker<Employee> GenerateEmployies()

    {
        return new Faker<Employee>("en")
            .RuleFor(x => x.Id, Guid.NewGuid)
            .RuleFor(x => x.Name, x => x.Person.FirstName)
            .RuleFor(x => x.LastName, x => x.Person.LastName)
            .RuleFor(x => x.Position, x => x.Name.JobTitle())
            .RuleFor(x => x.Salary, x => x.Random.Int(700, 5000))
            .RuleFor(x => x.Company, x => x.Company.CompanyName())
            .RuleFor(x => x.CompanyCountry, x => x.Address.Country())
            .RuleFor(x => x.CompanyCity, x => x.Address.City())
            .RuleFor(x => x.CompanyStreet, x => x.Address.StreetAddress());
    }

    public static Faker<Candidate> GenerateCandidates()
    {
        return new Faker<Candidate>("en")
            .RuleFor(p => p.Id, Guid.NewGuid)
            .RuleFor(p => p.Name, p => p.Person.FirstName)
            .RuleFor(p => p.LastName, p => p.Person.LastName)
            .RuleFor(p => p.Position, p => p.Name.JobTitle())
            .RuleFor(p => p.PositionDescription, p => p.Name.JobDescriptor())
            .RuleFor(p => p.DesiredSalary, p => p.Random.Int(1000, 5000));
    }
}
