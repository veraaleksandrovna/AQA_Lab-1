namespace DriverAndCars;

public class Vehicle
{
    public Model Model { get; set;}

    public int Year { get; set;}

    public Driver Owner { get; init; }

    public double Capacity { get; set; }

    public int Power { get; set;}

    public FuelType FType { get; set; }

    public int MaxSpeed { get;set; }
}
