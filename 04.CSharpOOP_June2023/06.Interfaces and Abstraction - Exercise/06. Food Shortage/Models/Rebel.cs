using P04.BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.BorderControl.Models
{
    public class Rebel : IBuyer
    {        
        public Rebel(string name, int age, string group, int food)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = food;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; private set; }
        public int Food { get; private set; }

        public bool BuyFood(string name)
        {
            if (ValidName(name))
            {
                Food += 5;
                return true;
            }
            return false;
        }
        private bool ValidName(string name)
        {
            if (Name == name)
            {
                return true;
            }
            return false;
        }
    }
}
