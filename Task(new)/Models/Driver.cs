namespace DriverAndCars
{
    public class Driver:Person
    {
        public DateTimeOffset DateDriverLicence { get; set; }
        public Guid ID { get; set; }


        public override bool Equals(object? obj)
        {
            var anotherDriver = obj as Driver;
            return anotherDriver!.FirstName!.Equals(FirstName) && anotherDriver.LastName!.Equals(LastName);
        }
    }
}
