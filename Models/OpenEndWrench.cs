using GarageSimulation.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageSimulation.Models
{
    class OpenEndWrench : IWrench
    {
        public int Size { get; set; }

        public void Apply()
        {
            Console.WriteLine($"Open end wrench of size {Size} was applied");
        }
    }
}
