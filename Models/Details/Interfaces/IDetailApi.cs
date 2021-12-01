using GarageSimulation.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageSimulation.Models
{
    public interface IDetailApi
    {
        public void Install(Vehicle vehicle, Detail detail);
    }
}
