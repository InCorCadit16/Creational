

using GarageSimulation.Models;

namespace GarageSimulation.Builders
{
    public abstract class VehicleBuilder
    {
        protected Vehicle vehicle;

        public VehicleBuilder()
        {
            vehicle = new Vehicle(1);
        }

        public VehicleBuilder SetRegistrationNumber(string number)
        {
            vehicle.RegistrationNumber = number;
            return this;
        }

        public VehicleBuilder SetManufacturer(string manufacturer)
        {
            vehicle.Manufacturer = manufacturer;
            return this;
        }

        public VehicleBuilder SetModel(string model)
        {
            vehicle.Model = model;
            return this;
        }

        public VehicleBuilder SetEngineVolume(int volume)
        {
            vehicle.EngineVolume = volume;
            return this;
        }

        public Vehicle CreateVehicle()
        {
            return vehicle;
        }
    }

    class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            vehicle = new Car();
        }
    }

    class MotorbikeBuilder : VehicleBuilder
    {
        public MotorbikeBuilder()
        {
            vehicle = new Motorbike();
        }
    }
}
