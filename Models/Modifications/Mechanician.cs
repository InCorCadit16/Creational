using Creational.Singletones;
using GarageSimulation.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageSimulation.Models
{
    public class Mechanician
    {
        private readonly Garage garage;
        public string Name { get; set; }
        public int Proficiency { get; set; }


        public Mechanician(Garage garage)
        {
            this.garage = garage;
        }

        public void ModifyVehicle(Car car, ICarModification modification)
        {
            garage.DoCarWorks(car, modification, this);
        }
    }
}
