namespace DriverAndCars
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var drivers = FakeData.CreateDriver(3);
            PrintDrivers(drivers);
            var vehicles = new List<Vehicle>();
            vehicles.AddRange(FakeData.CreateVehicle(drivers, 3));

            Driver chosenDriver;
            do
            {
                if (InputDriver(drivers, out chosenDriver)) break;
            } while (true);


            Console.WriteLine("1.Show technical characteristics of all vehicles");
            Console.WriteLine("2.Show other characteristics");
            var newChoice = Int32.Parse(Console.ReadLine() ?? string.Empty);

            switch (newChoice)
            {
                case 1:
                    PrintVehciles(vehicles);

                    break;

                case 2:
                    Console.WriteLine("1.Driving experience");
                    Console.WriteLine("2.Count time");
                    var caseChoice = double.Parse(Console.ReadLine());
                    switch (caseChoice)
                    {
                        case 1:
                            Console.WriteLine(
                                $"Date of License is {chosenDriver.DateDriverLicence.Date.ToString("d")}");
                            var driverExperience = chosenDriver.CountExperience();
                            Console.WriteLine($"Experience is {driverExperience} years");
                            break;
                        case 2:
                            CountTime(vehicles);
                            break;
                    }

                    break;
            }
        }

        private static bool InputDriver(List<Driver> drivers, out Driver chosenDriver)
        {
            Console.WriteLine($"Choose driver (1-{drivers.Count}):");
            var choice = Int32.Parse(Console.ReadLine());
            if (choice is >= 1 and <= 3)
            {
                chosenDriver = drivers[choice - 1];
                return true;
            }

            chosenDriver = null;
            return false;
        }

        private static void CountTime(List<Vehicle> vehicles)
        {
            Console.WriteLine("WAY:");
            var way = double.Parse(Console.ReadLine());
            foreach (var vehicle in vehicles)
            {
                var time = way / vehicle.MaxSpeed;
                Console.WriteLine($"Time in road is {time:F1} hours");
            }
        }

        private static void PrintDrivers(List<Driver> drivers)
        {
            foreach (var driver in drivers)
            {
                Console.WriteLine($"{driver.FirstName}  {driver.LastName} | {driver.DateOfBirth.Date.ToString("d")} " +
                                  $" | {driver.DateDriverLicence.Date.ToString("d")}");
            }
        }

        private static void PrintVehciles(List<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(
                    $"{vehicle.Model} | {vehicle.Year} | {vehicle.Capacity:F1}  |  {vehicle.MaxSpeed} | {vehicle.Power}");
            }
        }

        public static int CountExperience(this Driver driver)
        {
            return DateTime.Now.Year - driver.DateDriverLicence.Year;
        }
    }
}
