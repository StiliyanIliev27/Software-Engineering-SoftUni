

using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new();
            
            int n = int.Parse(Console.ReadLine());            

            for (int i = 0; i < n; i++)
            {                               
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
               
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(name, age);
                people.Add(person);
            }            
            
            foreach(var person in people.OrderBy(x => x.Name))
            {
                if(person.Age > 30)
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }

        }
    }
}