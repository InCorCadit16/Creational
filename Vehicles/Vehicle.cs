using System;
using System.Collections.Generic;
using System.Text;

namespace Creational.Vehicles
{
    public class Vehicle
    {
        public string RegistrationNumber { get; set; }
        public readonly int WheelsCount;
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int EngineVolume { get; set; }

        public Vehicle(int WheelsCount)
        {
            this.WheelsCount = WheelsCount;
        }

    }
}
