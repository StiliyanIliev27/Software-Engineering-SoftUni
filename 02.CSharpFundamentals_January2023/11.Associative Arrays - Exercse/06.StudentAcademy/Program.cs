namespace _06.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentInfo = new Dictionary<string, List<double>>();


            for (int i = 0; i < n; i++)
            {
                string key = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentInfo.ContainsKey(key))
                {
                    studentInfo[key] = new List<double>();
                }
                studentInfo[key].Add(grade);
            }
            foreach (var kvp in studentInfo)
            {
                if (kvp.Value.Average() >= 4.50 && kvp.Value.Average() <= 6.00)
                {
                    Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():f2}");
                }
            }
        }
    }
}
