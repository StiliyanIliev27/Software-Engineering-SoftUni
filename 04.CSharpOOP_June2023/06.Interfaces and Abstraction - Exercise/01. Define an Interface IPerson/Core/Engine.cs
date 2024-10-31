using P01.PersonInfoInterface.Core.Interfaces;
using PersonInfo;
using System;
using System.Collections.Generic;
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
          
            IPerson person = new Citizen(name, age); 
           
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}
