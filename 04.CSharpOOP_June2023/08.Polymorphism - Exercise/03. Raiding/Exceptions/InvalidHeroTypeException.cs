using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Exceptions
{
    public class InvalidHeroTypeException : Exception
    {
        private const string InvalidHeroTypeMessage = "Invalid hero!";
        public InvalidHeroTypeException() : base(InvalidHeroTypeMessage)
        {                
        }
    }
}
