using GarageSimulation.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageSimulation.Models.Modifications
{
    class ReplaceBrakesModification : ICarModification
    {
        public void Apply(Car car, int proficiency)
        {
            if (proficiency > 1)
            {
                Console.WriteLine($"Changed brakes on {car.Manufacturer} {car.Model}.");
            } else
            {
                Console.WriteLine($"Failed to change brakes on {car.Manufacturer} {car.Model}. Mecanic has no enough proficience.");
            }
        }
    }
}
