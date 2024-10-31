using P04.BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.BorderControl.Models
{
    public class Citizen : ISoldier
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }

        public string GetFakeId(string id)
        {
            if(IsFake(id))
            {
                return Id;
            }
            return "";
        }
        private bool IsFake(string id)
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
