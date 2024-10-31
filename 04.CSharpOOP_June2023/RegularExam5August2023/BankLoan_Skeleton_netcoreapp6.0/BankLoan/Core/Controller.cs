using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private IRepository<IBank> banks;
        private IRepository<ILoan> loans;
        public Controller()
        {
            banks = new BankRepository();
            loans = new LoanRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            if(bankTypeName != nameof(BranchBank) && bankTypeName != nameof(CentralBank))
            {
                throw new ArgumentException("Invalid bank type.");
            }

            Bank bank;
            if(bankTypeName == nameof(BranchBank))
            {
                bank = new BranchBank(name);                
            }
            else
            {
                bank = new CentralBank(name);
            }

            banks.AddModel(bank);
            return $"{bankTypeName} is successfully added.";
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            if(clientTypeName != nameof(Adult) && clientTypeName != nameof(Student))
            {
                throw new ArgumentException("Invalid client type.");
            }

            IBank bank = banks.Models.FirstOrDefault(b => b.Name == bankName);

            if(bank.GetType().Name == nameof(BranchBank))
            {
                if (clientTypeName == nameof(Student))
                {
                    Client student = new Student(clientName, id, income);
                    bank.AddClient(student);
                    return $"{clientTypeName} successfully added to {bankName}.";
                }
                else//exception 
                {
                    return "Unsuitable bank.";
                }
            }
            else
            {
                if(clientTypeName == nameof(Adult))
                {
                    Client adult = new Adult(clientName, id, income);
                    bank.AddClient(adult);
                    return $"{clientTypeName} successfully added to {bankName}.";
                }
                else//exception 
                {
                    return "Unsuitable bank.";
                }
            }
        }

        public string AddLoan(string loanTypeName)
        {
            if (loanTypeName != nameof(MortgageLoan) && loanTypeName != nameof(StudentLoan))
            {
                throw new ArgumentException("Invalid loan type.");
            }

            Loan loan;
            if(loanTypeName == nameof(StudentLoan))
            {
                loan = new StudentLoan();
            }
            else
            {
                loan = new MortgageLoan();
            }

            loans.AddModel(loan);
            return $"{loanTypeName} is successfully added.";
        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = banks.Models.FirstOrDefault(x => x.Name == bankName);

            double funds = 0;
            
            foreach(var client in bank.Clients)
            {
                funds += client.Income;             
            }

            foreach(var loan in bank.Loans)
            {
                funds += loan.Amount;
            }

            return $"The funds of bank {bankName} are {funds:f2}.";
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = loans.Models.FirstOrDefault(l => l.GetType().Name == loanTypeName);

            if(loan == null)
            {
                throw new ArgumentException($"Loan of type {loanTypeName} is missing.");
            }

            IBank bank = banks.Models.First(b => b.Name == bankName);
            bank.AddLoan(loan);
            loans.RemoveModel(loan);

            return $"{loanTypeName} successfully added to {bankName}.";
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();
           
            foreach(var bank in banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
