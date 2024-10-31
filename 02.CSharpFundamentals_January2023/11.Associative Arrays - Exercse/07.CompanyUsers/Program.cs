namespace _07.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyInfo = new Dictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] commandInfo = command.Split(" -> ");
                string companyName = commandInfo[0];
                string employeeId = commandInfo[1];

                if (!companyInfo.ContainsKey(companyName))
                {
                    companyInfo.Add(companyName, new List<string>());
                }
                if (companyInfo[companyName].Contains(employeeId))
                {
                    continue;
                }
                companyInfo[companyName].Add(employeeId);
            }
            foreach (var kvp in companyInfo)
            {
                Console.WriteLine(kvp.Key);

                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
