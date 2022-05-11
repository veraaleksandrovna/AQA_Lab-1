using Bogus;
using TestRail_Example.Models;

namespace RESTapi.Fakers;

public sealed class MilestoneFaker : Faker<Milestone>
{
    public MilestoneFaker()
    {
        RuleFor(b => b.Name, f => f.Company.CompanyName());
        RuleFor(b => b.Description, f => f.Company.CatchPhrase());
        RuleFor(b => b.IsStarted, f => true);
    }
}
