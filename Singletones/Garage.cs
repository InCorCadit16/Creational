using GarageSimulation.Models;
using GarageSimulation.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Creational.Singletones
{
    public class Garage
    {
        private static object obj = new object();
        private readonly List<Vehicle> Vehicles;
        private readonly List<Mechanician> Mechanicians;
        private static Garage instance;

        private Garage()
        {
            Vehicles = new List<Vehicle>();
            Mechanicians = new List<Mechanician>();
        }

        public static Garage GetGarage()
        {
            lock (obj)
                if (instance == null)
                    instance = new Garage();

            return instance;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
        }

        public Vehicle GetVehicle(string regNumber)
        {
            return Vehicles.FirstOrDefault(v => v.RegistrationNumber == regNumber);
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            Vehicles.Remove(vehicle);
        }

        public void AddMechanician(Mechanician mechanician)
        {
            Mechanicians.Add(mechanician);
        }

        public Mechanician GetMechanician(int index)
        {
            return Mechanicians[index];
        }

        public void RemoveMechanician(Mechanician mechanician)
        {
            Mechanicians.Remove(mechanician);
        }

        public void DoCarWorks(Car car, ICarModification modification, Mechanician mech)
        {
            Console.WriteLine($"\nMechanician {mech.Name} started to work on {car.Manufacturer} {car.Model}");
            modification.Apply(car, mech.Proficiency);
            Console.WriteLine();
        }

        public void PrintVehicles()
        {
            foreach (var veh in Vehicles)
            {
                Console.WriteLine($"\nReg. Number: {veh.RegistrationNumber}\nManufacturer: {veh.Manufacturer}\nModel: {veh.Model}" +
                    $"\nEngine Volume: {veh.EngineVolume} cm3\n\n");
            }
        }

    }
}
