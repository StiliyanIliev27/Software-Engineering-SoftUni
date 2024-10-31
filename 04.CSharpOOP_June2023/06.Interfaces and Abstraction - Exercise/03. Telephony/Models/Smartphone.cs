using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            if (!ValidateURLs(url))
            {
                throw new InvalidOperationException("Invalid URL!");
            }
            else
            {
                return $"Browsing: {url}!";
            }
        }

        public string Call(string phoneNumber)
        {
            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidOperationException("Invalid number!");
            }
            if(phoneNumber.Length == 10)
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
            foreach(char ch in phoneNumber)
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
        private bool ValidateURLs(string url)
        {
            foreach(char ch in url)
            {
                if (char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
