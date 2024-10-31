using SingletonDemo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class LoadBalancer
    {
        private static readonly LoadBalancer instance = new LoadBalancer();

        private readonly List<Server> servers;
        private readonly Random random = new Random();

        private LoadBalancer()
        {
            servers = new List<Server>
            {
                new Server { Name = "ServerI", IP = "120.14.220.18"},
                new Server { Name = "ServerII", IP = "120.14.220.19"},
                new Server { Name = "ServerIII", IP = "120.14.220.20"},
                new Server { Name = "ServerIV", IP = "120.14.220.21"},
                new Server { Name = "ServerV", IP = "120.14.220.22"}
            };
        }

        public static LoadBalancer GetLoadBalancer()
        {
            return instance;
        }
        public Server NextServer
        {
            get
            {
                int n = random.Next(servers.Count);
                return servers[n];   
            }
        }
    }
}
