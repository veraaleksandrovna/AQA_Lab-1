using Bogus;
using static DriverAndCars.Constants;

namespace DriverAndCars;

public class FakeData
{
    private static readonly Faker Faker;

    static FakeData()
    {
        Faker = new Faker();
    }

    public static List<Driver> CreateDriver(int count)
    {
        var driverFaker = new Faker<Driver>()
            .RuleFor(driver => driver.FirstName, faker => faker.Person.FirstName)
            .RuleFor(driver => driver.LastName, faker => faker.Person.LastName)
            .RuleFor(driver => driver.DateOfBirth, faker => faker.Person.DateOfBirth.Date)
            .RuleFor(driver => driver.Driver, faker => faker.Random.Bool());
        var driverList = driverFaker.Generate(count);
        driverList.ForEach(driver =>
        {
            driver.DateDriverLicence = Faker.Date.Between(driver.DateOfBirth.AddYears(minAge), DateTime.Now);
            driver.ID = Guid.NewGuid();
        });

        return driverList;
    }

    public static List<Vehicle> CreateVehicle(List<Driver> drivers, int count)
    {
        var vehicleFake = new Faker<Vehicle>(language)
            .RuleFor(v => v.Model, v => v.PickRandom<Model>())
            .RuleFor(v => v.Year, v => v.Random.Int(minYear, maxYear))
            .RuleFor(f => f.Capacity, f => f.Random.Double(minCapacity, maxCapacity))
            .RuleFor(f => f.Power, f => f.Random.Int(minPower, maxPower))
            .RuleFor(f => f.FuelType, f => f.PickRandom<FuelType>())
            .RuleFor(f => f.MaxSpeed, f => f.Random.Int(minSpeed, maxSpeed));
        var vehicleList = vehicleFake.Generate(count);

        return vehicleList;
    }
}
