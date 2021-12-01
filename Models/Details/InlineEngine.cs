using GarageSimulation.Models.Interfaces;
using System;

namespace GarageSimulation.Models
{
    class InlineEngine : IDetailApi
    {
        public void Install(Vehicle vehicle, Detail detail)
        {
            Console.WriteLine($"Installing new inline engine in {vehicle}. {detail}");
        }
    }
}
