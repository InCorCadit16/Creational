﻿using GarageSimulation.Models;
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
        private static Garage instance;

        private Garage()
        {
            Vehicles = new List<Vehicle>();
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