namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int capacityOfWagons = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandInfo = command.Split().ToArray();


                if (commandInfo.Length == 2)
                {
                    int passengers = int.Parse(commandInfo[1]);
                    wagons.Add(passengers);
                }
                else if (commandInfo.Length == 1)
                {
                    int passengers = int.Parse(commandInfo[0]);

                    // int wagon = wagons.First(peopleInWagon => peopleInWagon + passengers <= capacityOfWagons);
                    // wagons[wagon] += passengers; => Possible method! Instead of using For Loop we can do the same with LINQ!

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + passengers <= capacityOfWagons)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
