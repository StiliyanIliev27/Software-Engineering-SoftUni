using MockingAndTestDrivenDevelopmentBeta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingAndTestDrivenDevelopmentBeta.Models
{
    public class AccountManager : IAccountManager
    {
        public AccountManager(string username, string password, string email, string id)
        {
            Account = new Account(username, password, email, id);
        }
        public Account Account { get; private set; }
    }
}
