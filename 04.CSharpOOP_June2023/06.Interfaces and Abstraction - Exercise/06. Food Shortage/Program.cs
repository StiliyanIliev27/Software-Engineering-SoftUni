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
            List<IBuyer> buyers = new List<IBuyer>();
            
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = command[0];
                int age = int.Parse(command[1]);

                if(command.Length == 4)//citizen
                {
                    string id = command[2];
                    string birthdate = command[3];

                    IBuyer citizen = new Citizen(name, age, id, birthdate, 0);
                    buyers.Add(citizen);
                }
                else//rebel
                {
                    string group = command[2];

                    IBuyer rebel = new Rebel(name, age, group, 0);
                    buyers.Add(rebel);
                }
            }

            string secondCommand = Console.ReadLine();
            while(secondCommand != "End")
            {
                string name = secondCommand;
                
                foreach(var buyer in buyers)
                {
                    if (buyer.BuyFood(name))
                    {                     
                        break;
                    }
                }
                secondCommand = Console.ReadLine();
            }
            
            int totalFood = buyers.Sum(x => x.Food);
            Console.WriteLine(totalFood);
        }
//4
//Stam 23 TheSwarm
//Ton 44 7308185527 18/08/1973
//George 31 Terrorists
//Pen 27 881222212 22/12/1988
    }
}