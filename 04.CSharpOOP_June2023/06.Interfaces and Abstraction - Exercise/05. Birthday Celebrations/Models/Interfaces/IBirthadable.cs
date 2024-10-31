using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.BorderControl.Models.Interfaces
{
    public interface IBirthadable
    {
        public string Birthdate { get; }
        public string GetBirthdate(string birthdate);
    }
}
