using System;
using System.Collections.Generic;
using System.Text;

namespace GarageSimulation.Models.Interfaces
{
    abstract class Detail
    {
        public readonly IDetailApi detailApi;

        public Detail(IDetailApi detailApi)
        {
            this.detailApi = detailApi;
        }

        public abstract void Install(Vehicle vehicle);

        public abstract override string ToString();
    }
}
