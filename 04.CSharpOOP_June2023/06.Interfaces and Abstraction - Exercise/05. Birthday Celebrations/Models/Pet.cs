using P04.BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.BorderControl.Models
{
    public class Pet : IBirthadable
    {
        public Pet(string name, string birthday)
        {
            Name = name;
            Birthdate = birthday;
        }

        public string Name { get; private set; }
        public string Birthdate { get; private set; }

        public string GetBirthdate(string birthdate)
        {
            string reversedYear = string.Empty;

            for (int i = Birthdate.Length - 1; i >= 0; i--)
            {
                if (Birthdate[i] == '/')
                {
                    break;
                }
                reversedYear += Birthdate[i];
            }

            string year = string.Empty;

            for (int i = reversedYear.Length - 1; i >= 0; i--)
            {
                year += reversedYear[i];
            }

            if (year == birthdate)
            {
                return Birthdate;
            }

            return "";
        }
    }
}
