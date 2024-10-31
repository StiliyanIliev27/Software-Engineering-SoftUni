using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private readonly List<ILoan> loans;
        private readonly List<IClient> clients;

        protected Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            clients = new List<IClient>();
            loans = new List<ILoan>();
        }

        public string Name
        {
            get => name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Bank name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<ILoan> Loans => loans.AsReadOnly();

        public IReadOnlyCollection<IClient> Clients => clients.AsReadOnly();

        public void AddClient(IClient Client)
        {
            if(Capacity >= Clients.Count)
            {
                clients.Add(Client);
            }
            else
            {
                throw new ArgumentException("Not enough capacity for this client.");
            }
        }

        public void AddLoan(ILoan loan)
        {
           loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}, Type: {this.GetType().Name}");

            List<string> names = new List<string>();

            foreach(var client in Clients)
            {
                names.Add(client.Name);
            }

            string clients = Clients.Any() ? $"{string.Join(", ", names)}" : "none";

            sb.AppendLine($"Clients: {clients}");
            sb.AppendLine($"Loans: {Loans.Count}, Sum of Rates: {SumRates()}");

            return sb.ToString().TrimEnd();
        }

        public void RemoveClient(IClient Client)
        {
            clients.Remove(Client);
        }

        public double SumRates()
        {
            double sum = 0; 
            
            foreach(var loan in Loans)
            {
                sum += loan.InterestRate;
            }

            return sum;
        }
    }
}
