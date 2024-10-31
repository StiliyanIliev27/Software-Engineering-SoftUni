namespace _02.MinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "stop")
                {
                    break;
                }
                int value = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(command))
                {
                    resources.Add(command, 0);
                }
                resources[command] += value;
            }
            foreach (var kvp in resources)
            {
                Console.WriteLine($"{kvp.Key} -> {string.Join(" ", kvp.Value)}");
            }
        }
    }
}
