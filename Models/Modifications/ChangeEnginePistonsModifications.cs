using GarageSimulation.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageSimulation.Models.Modifications
{
    class ChangeEnginePistonsModifications : ICarModification
    {
        public void Apply(Car car, int proficiency)
        {
            if (proficiency > 2)
            {
                Console.WriteLine($"Changed pistons in {car.Manufacturer} {car.Model} engine.");
            } else
            {
                Console.WriteLine($"Failed to change pistons in {car.Manufacturer} {car.Model} engine. Mecanic has no enough proficience.");
            }
              
        }
    }
}
