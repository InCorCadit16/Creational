using GarageSimulation.Builders;

namespace GarageSimulation.Factories
{
    public abstract class VehicleFactory
    {
        public abstract VehicleBuilder GetVehicleBuilder();
    }

    public class CarFactory : VehicleFactory
    {
        public override VehicleBuilder GetVehicleBuilder()
        {
            return new CarBuilder();
        }
    }

    public class MotorbikeFactory : VehicleFactory
    {
        public override VehicleBuilder GetVehicleBuilder()
        {
            return new MotorbikeBuilder();
        }
    }
}
