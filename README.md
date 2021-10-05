# Topic: Creational Design Patterns
## Author: Rosca Alexandru

## Theory:
Creational design patterns are design patterns that create objects using most suitable object creation mechanism. 
Basic creational design patterns are :

* Singleton
* Builder
* Prototype
* Object Pooling
* Factory Method
* Abstract Factory

## Implementation:

The application contains 4 main classes. First of them is Garage class, which implements Singleton pattern:
        
        private static Garage instance;
        
        private Garage()
        {
            Vehicles = new List<Vehicle>();
        }

        public static Garage GetGarage()
        {
            lock (obj)
            {
                if (instance == null)
                    instance = new Garage();
            }

            return instance;
        }
    
Second is Vehicle which is the core Entity in the application. Third is VehicleBuilder which implement Builder pattern and allows to setup vehicles:

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

List is VehicleFactory which is an implementation of AbstractFactory design pattern:

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

## Screenshot
  ![Alt Text](https://i.ibb.co/d4gN4CV/Screenshot-2021-10-05-231550.png)
