using GarageSimulation.Models.Interfaces;
using System;

namespace GarageSimulation.Models
{
    class RotorEngine : IDetailApi
    {
        public void Install(Vehicle vehicle, Detail detail)
        {
            Console.WriteLine($"Installing new rotor engine in {vehicle}. {detail}");
        }
    }
}
