namespace DriverAndCars;

public class Vehicle
{
    public Vehicle(FuelType fType, int power, int maxSpeed, double capacity, int year, Model model)
    {
        FType = fType;
        Power = power;
        MaxSpeed = maxSpeed;
        Capacity = capacity;
        Year = year;
        Model = model;
    }

    public Model Model { get; }
    public int Year { get; }
    public Driver Owner { get; init; }
    public double Capacity { get; }
    public int Power { get; }
    public FuelType FType { get; }
    public int MaxSpeed { get; }
}
