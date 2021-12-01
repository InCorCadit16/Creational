using GarageSimulation.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageSimulation.Models.Modifications
{
    public class ChangeBoostModification : ICarModification
    {

        public void Apply(Car car, int proficiency) 
        {
            if (typeof(TurboChargedEngine) == car.Engine.GetType())
            {
                var engine = (TurboChargedEngine)car.Engine;
                engine.Boost += proficiency * 0.3f;
                Console.WriteLine($"Boosted {car.Manufacturer} {car.Model} by {proficiency * 0.3f}.");
            } else
            {
                Console.WriteLine($"Cannot boost {car.Manufacturer} {car.Model} because its engine has no turbo.");
            }
        }
    }
}
