using P01.PersonInfoInterface.Core.Interfaces;
using PersonInfo;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.PersonInfoInterface.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine(); 
           
            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);            
            IBirthable birthable = new Citizen(name, age, id, birthdate);
           
            Console.WriteLine(identifiable.Id);
            Console.WriteLine(birthable.Birthdate);
        }
    }
}
