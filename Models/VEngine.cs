using GarageSimulation.Models.Interfaces;
using System;

namespace GarageSimulation.Models
{
    class VEngine : IDetailApi
    {
        public void Install(Vehicle vehicle, Detail detail)
        {
            Console.WriteLine($"Installing new V engine in {vehicle}. {detail}");
        }
    }
}
