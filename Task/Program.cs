namespace Task2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Driver driver1 = new Driver();
            Driver driver2 = new Driver();
            Driver driver3 = new Driver();
            Engine engine1 = new Engine(4,200,Engine.FuelType.Electric,200);
            Engine engine2 = new Engine(3,150,Engine.FuelType.Diesel,120);
            Vehicle vehicle1 = new Vehicle("Audi", 2015, null, engine1);
            Vehicle vehicle2 = new Vehicle("BMW", 2017, null, engine2);
            Vehicle vehicle3 = new Vehicle("Volvo", 2017, null, engine1);
            driver1._vehicles.Add(vehicle1);
            driver1._vehicles.Add(vehicle2);
            driver2._vehicles.Add(vehicle3);
            driver3._vehicles.Add(vehicle1);
            Console.WriteLine("Выберите водителя :");
            Console.WriteLine("Введите 1/2/3");
            var choose = Console.ReadLine();
            Driver pickedDriver;
            switch (choose)
            {
                case "1":
                    pickedDriver = driver1;
                    break;
                case "2":
                    pickedDriver = driver2;
                    break;
                case "3":
                    pickedDriver = driver3;
                    break;
                default:
                    Console.WriteLine("Ошибка ввода!");
                    return;
            }
            Console.WriteLine("Информация о машинах:");
            foreach (var vehicle in pickedDriver._vehicles)
            {
                Console.WriteLine(vehicle.Model);
                Console.WriteLine(vehicle.Year);
                Console.WriteLine(vehicle.Engine.Capacity);
                Console.WriteLine(vehicle.Engine.MaxSpeed);
            }
            Console.WriteLine("Стаж вождения:");
            Console.WriteLine((DateTime.Now -pickedDriver.DateDriverLicence).TotalDays/365 +"года");
        }
    }
}
