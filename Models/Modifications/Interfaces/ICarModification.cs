using System;
using System.Collections.Generic;
using System.Text;

namespace GarageSimulation.Models.Interfaces
{
    public interface ICarModification
    {
        public abstract void Apply(Car car, int proficiency);
    }
}
