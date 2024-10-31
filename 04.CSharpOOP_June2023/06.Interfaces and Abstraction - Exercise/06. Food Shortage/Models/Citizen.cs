using P04.BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.BorderControl.Models
{
    public class Citizen : ISoldier, IBirthadable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate, int food)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            Food = food;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Birthdate { get; private set; }
        public int Food { get; private set; }

        public bool BuyFood(string name)
        {
            if (ValidName(name))
            {
                Food += 10;
                return true;
            }
            return false;
        }
        private bool ValidName(string name)
        {
            if(Name == name)
            {
                return true;
            }
            return false;
        }

        public string GetBirthdate(string birthdate)
        {
            string reversedYear = string.Empty;

            for(int i = Birthdate.Length - 1; i >= 0; i--)
            {
                if (Birthdate[i] == '/')
                {
                    break;
                }
                reversedYear += Birthdate[i];               
            }

            string year = string.Empty;
            
            for(int i = reversedYear.Length - 1; i >= 0; i--)
            {
                year += reversedYear[i]; 
            }
            
            if(year == birthdate)
            {
                return Birthdate;
            }

            return "";
        }
        public string GetFakeId(string id)
        {
            if(IsFakeId(id))
            {
                return Id;
            }
            return "";
        }
        private bool IsFakeId(string id)
        {
            int cnt = 0;
            string result = string.Empty;

            for (int i = Id.Length - 1; i >= 0; i--)
            {
                result += Id[i];

                cnt++;

                if (cnt == id.Length)
                {
                    break;
                }
            }

            string reversedResult = string.Empty;

            for (int i = result.Length - 1; i >= 0; i--)
            {
                reversedResult += result[i];
            }

            if (reversedResult == id)
            {
                return true;
            }
            return false;
        }
    }
}
