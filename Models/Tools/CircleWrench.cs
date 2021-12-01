using GarageSimulation.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageSimulation.Models
{
    class CircleWrench : IWrench
    {
        public int Size { get; set; }

        public void Apply()
        {
            Console.WriteLine($"Circle wrench of size {Size} was applied");
        }
    }
}
