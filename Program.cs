using Creational.Singletones;
using GarageSimulation.Factories;
using GarageSimulation.FlyWeights;
using GarageSimulation.Models;
using System;
using System.Collections.Generic;

namespace Creational
{
    class Program
    {

        static void Main(string[] args)
        {
            // AddCars();
            UseDetailsAndTools();
        }


        // Show functionality implemented with creational patterns
        public static void AddCars()
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
                    .SetRegistrationNumber(regNumber)
                    .SetManufacturer(manufacturer)
                    .SetModel(model)
                    .SetEngineVolume(engineVolume)
                    .CreateVehicle();

                garage.AddVehicle(vehicle);
            }

            Console.WriteLine("Your garage.\n");
            garage.PrintVehicles();
        }


        // Show functionality implemented with structural patterns
        public static void UseDetailsAndTools()
        {
            var garage = Garage.GetGarage();
            var carFactory = new CarFactory();
            garage.AddVehicle
            (
                carFactory.GetVehicleBuilder()
                .SetRegistrationNumber("AZD153")
                .SetManufacturer("Mazda")
                .SetModel("RX-7")
                .SetEngineVolume(1300)
                .CreateVehicle()
            );

            var inlineEngine = new Engine(new InlineEngine());
            var VEngine = new Engine(new VEngine());

            inlineEngine.Volume = 2500;
            inlineEngine.CylinderNumber = 6;
            inlineEngine.Install(garage.GetVehicle("AZD153"));


            VEngine.Volume = 4400;
            VEngine.CylinderNumber = 8;
            VEngine.Install(garage.GetVehicle("AZD153"));

            var inlineTurbo = new TurboChargedEngine(inlineEngine);
            Console.WriteLine();
            Console.WriteLine(inlineTurbo);
            Console.WriteLine();

            // List of wrenchs required for some work in order in which they need to be used
            List<Tuple<string, int>> requiredTools = new List<Tuple<string, int>>(new Tuple<string, int>[] {
                new Tuple<string, int>("openEnd", 12),
                new Tuple<string, int>("pipe", 11),
                new Tuple<string, int>("openEnd", 8),
                new Tuple<string, int>("circle", 16),
                new Tuple<string, int>("circle", 14),
                new Tuple<string, int>("pipe", 24),
                new Tuple<string, int>("pipe", 18),
                new Tuple<string, int>("circle", 18)
            });

            foreach (var requirement in requiredTools)
            {
                var tool = WrenchsFactory.GetWrench(requirement.Item1);
                tool.Size = requirement.Item2;
                tool.Apply();
            }

        }
    }
}
