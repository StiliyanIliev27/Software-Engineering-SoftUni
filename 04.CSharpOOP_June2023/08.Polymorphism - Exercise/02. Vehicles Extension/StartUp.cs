using Vehicles.Core;
using Vehicles.Core.Interfaces;
using Vehicles.Factories;
using Vehicles.IO;
using Vehicles.IO.Interfaces;

namespace PolymorphismExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter(), new VehicleFactory());
            engine.Run();
        }
//Car 30 0.04 70
//Truck 100 0.5 300
//Bus 40 0.3 150
//8
//Refuel Car -10
//Refuel Truck 0
//Refuel Car 10
//Refuel Car 300
//Drive Bus 10
//Refuel Bus 1000
//DriveEmpty Bus 100
//Refuel Truck 1000
    }
}