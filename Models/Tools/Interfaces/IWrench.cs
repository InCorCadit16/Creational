using System;
using System.Collections.Generic;
using System.Text;

namespace GarageSimulation.Models.Interfaces
{
    interface IWrench
    {
        public int Size { get; set; }

        public void Apply();
    }
}
