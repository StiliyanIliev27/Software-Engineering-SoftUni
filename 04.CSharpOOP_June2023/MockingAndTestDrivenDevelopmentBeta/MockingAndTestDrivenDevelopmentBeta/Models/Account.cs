using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingAndTestDrivenDevelopmentBeta.Models
{
    public class Account
    {
        public Account(string username, string password, string email, string id)
        {
            Username = username;
            Password = password;
            Email = email;
            Id = id;
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Id { get; private set; }
    }
}
