using P04.BorderControl.Models;
using P04.BorderControl.Models.Interfaces;
using System.Diagnostics.Metrics;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandInfo.Length == 3)//citizen
                {
                    string name = commandInfo[0];
                    int age = int.Parse(commandInfo[1]);
                    string id = commandInfo[2];

                    ISoldier citizen = new Citizen(name, age, id);
                    soldiers.Add(citizen);
                }
                else//robot
                {
                    string model = commandInfo[0];
                    string id = commandInfo[1];

                    ISoldier robot = new Robot(model, id);
                    soldiers.Add(robot);
                }
                command = Console.ReadLine();
            }

            string idCheck = Console.ReadLine();

            foreach(var soldier in soldiers)
            {
                if(soldier.GetFakeId(idCheck) == "")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(soldier.GetFakeId(idCheck));
                }
            }
        }
    }
}