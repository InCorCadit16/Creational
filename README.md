# Topic: Behavioral Design Patterns
## Author: Rosca Alexandru

## Theory:
Behavioral design pattern are used to ensure an effective communication between entities.
Commonly used behavioral patterns:

* Chain of Responsibility
* Command
* Interpreter
* Iterator
* Mediator
* Observer
* Strategy


## Implementation:

In last commit I've decided to add functionality to modify the Car objects.
First of all I added the Mechanician class which is ables to do some car modifications using Garage class as Mediator:

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
 
Additional method in Garage class:

        public void DoCarWorks(Car car, ICarModification modification, Mechanician mech)
        {
            Console.WriteLine($"\nMechanician {mech.Name} started to work on {car.Manufacturer} {car.Model}");
            modification.Apply(car, mech.Proficiency);
            Console.WriteLine();
        }

Also, I decided to add ability to execute different modifications using Strategy pattern.
I've create interface ICarModification:

        public interface ICarModification
        {
            public abstract void Apply(Car car, int proficiency);
        }

And a few examples of real car modifications, such as this:

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

## Screenshot
  ![Alt Text](https://i.ibb.co/3NJNZN3/image.png)


# Topic: Structural Design Patterns
## Author: Rosca Alexandru

## Theory:
Structural Design Patterns are using inheritance and composition to organize objects and classes into some complex structure.
Most common structural patterns:

* Adapter
* Bridge
* Composite
* Decorator
* Facade
* Flyweight
* Proxy

# Implementation:

Additional functionality which uses structural patterns is presented through 2 new families of classes: Details and Wrenchs.
IDetailApi is an interface which can be used by any specific implementation of a Detail (Such as InlineEngine class). It helds only one method which allows to install this detail on any vehicle.

    interface IDetailApi
    {
        public void Install(Vehicle vehicle, Detail detail);
    }

Together with Detail abstract class and Engine class it implements Bridge pattern. Example of usage

    var inlineEngine = new Engine(new InlineEngine());
    var VEngine = new Engine(new VEngine());

    inlineEngine.Volume = 2500;
    inlineEngine.CylinderNumber = 6;
    inlineEngine.Install(garage.GetVehicle("AZD153"));


    VEngine.Volume = 4400;
    VEngine.CylinderNumber = 8;
    VEngine.Install(garage.GetVehicle("AZD153"));

Next class which helps to enlarge program functionality was adding the TurboChargedEngine class:

    class TurboChargedEngine : Engine
    {
        private Engine engine;

        public float Boost { get; set; }

        public TurboChargedEngine(Engine engine): base(engine.detailApi)
        {
            this.engine = engine;
            Boost = 1.3f;
        }

        public override string ToString()
        {
            return engine.ToString() + $"Charge type - Turbo; Boost - {Boost};";
        }
    }

It implements Proxy pattern, allowing to turbo charge any existing engine. Usage:

    var inlineEngine = new Engine(new InlineEngine());

    inlineEngine.Volume = 2500;
    inlineEngine.CylinderNumber = 6;
    inlineEngine.Install(garage.GetVehicle("AZD153"));
    
    var inlineTurbo = new TurboChargedEngine(inlineEngine);
    Console.WriteLine();
    Console.WriteLine(inlineTurbo);
    Console.WriteLine();

Another functionality available in programm is ability to create and use different types of Wrenchs. So as not to create multiple instances of Wrenches for different sizes, I decided to use FlyWeight pattern:

    class WrenchsFactory
    {
        private static readonly Dictionary<string, IWrench> wrenchs = new Dictionary<string, IWrench>();

        public static IWrench GetWrench(string type)
        {
            bool found = wrenchs.TryGetValue(type, out IWrench wrench);

            if (!found)
            {
                switch (type)
                {
                    case "openEnd": wrenchs.Add(type, new OpenEndWrench()); break;
                    case "pipe": wrenchs.Add(type, new PipeWrench()); break;
                    case "circle": wrenchs.Add(type, new CircleWrench()); break;
                }

                wrenchs.TryGetValue(type, out wrench);
            }

            return wrench;
        }
    }

Here is how it can be used:

    // List of wrenchs required for some work in order in which they need to be used
    List<Tuple<string, int>> requiredTools = new List<Tuple<string, int>>(new Tuple<string, int>[] {
        new Tuple<string, int>("openEnd", 12),
        new Tuple<string, int>("pipe", 11),
        new Tuple<string, int>("openEnd", 8),
        new Tuple<string, int>("circle", 16),
        new Tuple<string, int>("circle", 14),
        new Tuple<string, int>("pipe", 24),
        new Tuple<string, int>("pipe", 18),
        new Tuple<string, int>("circle", 18)
    });

    foreach (var requirement in requiredTools)
    {
        var tool = WrenchsFactory.GetWrench(requirement.Item1);
        tool.Size = requirement.Item2;
        tool.Apply();
    }

## Result:
  ![Alt Text](https://i.ibb.co/Dp6KQxd/Screenshot-2021-11-11-194317.png)



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
