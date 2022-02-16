namespace Task2
{
    public class Engine
    {
        public enum FuelType
        {
            Electric,
            Hydrogen,
            Diesel
        }

        public int Capacity { get;}
        public int Power { get;}
        public FuelType FType { get;}
        public int MaxSpeed { get;}

        public Engine(int capacity,int power,FuelType fuelType,int maxSpeed)
        {
            Capacity = capacity;
            Power = power;
            FType = fuelType;
            MaxSpeed = maxSpeed;

        }
    }
}
