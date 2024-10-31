using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidOperationException("Invalid number!");
            }
            if (phoneNumber.Length == 10)
            {
                return $"Calling... {phoneNumber}";
            }
            else
            {
                return $"Dialing... {phoneNumber}";
            }
        }
        private bool ValidatePhoneNumber(string phoneNumber)
        {
            foreach (char ch in phoneNumber)
            {
                if (char.IsDigit(ch))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
