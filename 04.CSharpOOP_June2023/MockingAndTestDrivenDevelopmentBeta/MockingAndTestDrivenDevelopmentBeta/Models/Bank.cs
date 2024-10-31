using MockingAndTestDrivenDevelopmentBeta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingAndTestDrivenDevelopmentBeta.Models
{
    public class Bank
    {
        private IAccountManager accountManager;

        public Bank(string accountManagerUsername, string accountManagerPassword, string accountManagerEmail, string id)
        {
            this.accountManager = new AccountManager(accountManagerUsername, accountManagerPassword, accountManagerEmail, id);
        }

        public string GetInfoById(string id)
        {
            StringBuilder sb = new StringBuilder();

            if(accountManager.Account.Id == id)
            {
                sb.AppendLine($"AccountManager username: {accountManager.Account.Username}");
                sb.AppendLine($"AccountManager password: {accountManager.Account.Password}");
                sb.AppendLine($"AccountManager email: {accountManager.Account.Email}");
                sb.AppendLine($"AccountManager id: {accountManager.Account.Id}");
            }
            else
            {
                return $"AccountManager with id: {id} doesn't exists";
            }

            return sb.ToString().TrimEnd();
        }
    }
}
