using System;

namespace Creational
{
    class Program
    {
        static void Main(string[] args)
        {
            var garage = Garage.GetGarage();
            var carFactory = new CarFactory();
            var bikeFactory = new MotorbikeFactory();

            Console.Write("How many vehicles do you have: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write($"\nVehicle {i + 1}. Is this vehicle car or bike: ");
                string type = Console.ReadLine();
                Console.Write("Reg. Number: ");
                string regNumber = Console.ReadLine();
                Console.Write("Manufacturer: ");
                string manufacturer = Console.ReadLine();
                Console.Write("Model: ");
                string model = Console.ReadLine();
                Console.Write("Engine Volume: ");
                int engineVolume = int.Parse(Console.ReadLine());
                var vehicle = (type == "car" ? carFactory.GetVehicleBuilder() : bikeFactory.GetVehicleBuilder())
                    .SetRegistrationNumber(regNumber).SetManufacturer(manufacturer).SetModel(model).SetEngineVolume(engineVolume)
                    .CreateVehicle();

                garage.AddVehicle(vehicle);
            }

            Console.WriteLine("Your garage.\n");
            garage.PrintVehicles();
        }
    }
}
