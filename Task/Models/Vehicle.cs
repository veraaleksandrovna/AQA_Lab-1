namespace Task2
{
    public class Vehicle
    {
        public string Model { get;}
        public int Year { get;}
        public Person Owner { get;}
        public Engine Engine { get;}

        public Vehicle(string model,int year,Person owner,Engine engine)
        {
            Model = model;
            Year = year;
            Owner = owner;
            Engine = engine;
        }
    }
}