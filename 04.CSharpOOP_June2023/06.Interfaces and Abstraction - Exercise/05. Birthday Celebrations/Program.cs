using P04.BorderControl.Models;
using P04.BorderControl.Models.Interfaces;
using System.Diagnostics.Metrics;
using System.Security;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthadable> objects = new List<IBirthadable>();
            
            string command = Console.ReadLine();
            while(command != "End")
            {
                string[] commandInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = commandInfo[0];
                string name = commandInfo[1];

                if (type == "Citizen")
                {
                    int age = int.Parse(commandInfo[2]);
                    string id = commandInfo[3];
                    string birthdate = commandInfo[4];

                    IBirthadable citizen = new Citizen(name, age, id, birthdate);
                    objects.Add(citizen);
                }
                else if (type == "Pet")
                {
                    string birthdate = commandInfo[2];

                    IBirthadable pet = new Pet(name, birthdate);
                    objects.Add(pet);
                }
                command = Console.ReadLine();
            }
            string dateGiven = Console.ReadLine();

            foreach(var currentObject in objects)
            {
                if(currentObject.GetBirthdate(dateGiven) == "")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(currentObject.GetBirthdate(dateGiven));
                }
            }
        }
    }
}