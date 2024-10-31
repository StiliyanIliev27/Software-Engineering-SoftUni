namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int countOfEngines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
           
            int displacement = 0;
            string efficiency = String.Empty;

            for (int i = 0; i < countOfEngines; i++)
            {
                string[] commandInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                /// "{model} {power} {displacement} {efficiency}"
                string model = commandInfo[0];
                int power = int.Parse(commandInfo[1]);

                if(commandInfo.Length >= 3)
                {
                    bool isNumeric = int.TryParse(commandInfo[2], out displacement);

                    if (isNumeric)
                    {
                        displacement = int.Parse(commandInfo[2]);
                    }
                    else
                    {
                        efficiency = commandInfo[2];
                    }

                    if (commandInfo.Length == 4)
                    {
                        efficiency = commandInfo[3];
                    }
                }
                
                Engine engine = new Engine();
                engine.Model = model;
                engine.Power = power;
                
                if (commandInfo.Length >= 3)
                {
                    engine.Displacement = displacement;                   
                    engine.Efficiency = efficiency;
                }

                engines.Add(engine);

            }

            int countOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            int weight = 0;
            string color = string.Empty;

            for(int i = 0; i < countOfCars; i++)
            {
                string[] commandInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                /// "{model} {engine} {weight} {color}"
                string model = commandInfo[0];
                string engineModel = commandInfo[1];

                if (commandInfo.Length >= 3)
                {                    
                    
                    bool isNumeric = int.TryParse(commandInfo[2], out weight);
                    
                    if (isNumeric)
                    {
                        weight = int.Parse(commandInfo[2]);
                    }
                    else
                    {
                        color = commandInfo[2];
                    }

                    if (commandInfo.Length == 4)
                    {
                        color = commandInfo[3]; 
                    }
                }

                Car car = new Car();
                car.Model = model;
                
                foreach(var engine in engines)
                {
                    if(engineModel == engine.Model)
                    {
                        car.Engine = engine;
                    }
                }

                if (commandInfo.Length >= 3)
                {
                    car.Weight = weight;                   
                    car.Color = color;
                }

                cars.Add(car);
            }

            foreach(var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                
                if(car.Engine.Displacement == 0)
                {
                    Console.WriteLine("    Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }

                if(car.Engine.Efficiency == "" || car.Engine.Efficiency == null)
                {
                    Console.WriteLine("    Efficiency: n/a");
                }
                else
                {
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                }

                if(car.Weight == 0)
                {
                    Console.WriteLine("  Weight: n/a");
                }
                else
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }
                
                
                if(car.Color == "" || car.Color == null)
                {
                    Console.WriteLine("  Color: n/a");
                }
                else
                {
                    Console.WriteLine($"  Color: {car.Color}");
                }
            }
        }
    }
}