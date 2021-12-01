using GarageSimulation.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageSimulation.Models
{
    public class Engine : Detail
    {
        public int Volume { get; set; }
        public int CylinderNumber { get; set; }

        public Engine(IDetailApi detailApi) : base(detailApi) { }

        public override void Install(Vehicle vehicle)
        {
            vehicle.EngineVolume = Volume;
            detailApi.Install(vehicle, this);
        }

        public override string ToString()
        {
            return $"Engine characteristincs: Volume - {Volume} cm3; Cylinder Number - { CylinderNumber };";
        }
    }
}
