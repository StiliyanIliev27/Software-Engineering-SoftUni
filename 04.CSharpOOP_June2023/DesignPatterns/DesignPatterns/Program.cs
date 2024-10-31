

namespace SingletonDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var b1 = LoadBalancer.GetLoadBalancer();
            var b2 = LoadBalancer.GetLoadBalancer();
            var b3 = LoadBalancer.GetLoadBalancer();
            var b4 = LoadBalancer.GetLoadBalancer();
            var b5 = LoadBalancer.GetLoadBalancer();

            if (b1 == b2 && b2 == b3 && b3 == b4 && b4 == b5)
            {
                Console.WriteLine("Same instance!");
            }

            LoadBalancer loadBalancer = LoadBalancer.GetLoadBalancer();

            // Loading 15 requests for the server...
            for(int i = 0; i < 15; i++)
            {
                string server = loadBalancer.NextServer.Name;
                Console.WriteLine($"Dispatch request to: {server}");
            }

            Console.ReadKey();
        }
    }
}