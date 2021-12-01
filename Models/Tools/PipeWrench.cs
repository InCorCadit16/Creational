using GarageSimulation.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageSimulation.Models
{
    class PipeWrench : IWrench
    {
        public int Size { get; set; }

        public void Apply()
        {
            Console.WriteLine($"Pipe wrench of size {Size} was applied");
        }
    }
}
