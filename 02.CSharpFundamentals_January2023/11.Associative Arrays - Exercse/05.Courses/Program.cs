namespace _05.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, List<string>> courseInfo = new Dictionary<string, List<string>>();

            while (command != "end")
            {
                string[] commandInfo = command.Split(" : ");
                string courseName = commandInfo[0];
                string username = commandInfo[1];

                if (!courseInfo.ContainsKey(courseName))
                {
                    courseInfo.Add(courseName, new List<string>());
                }

                courseInfo[courseName].Add(username);

                command = Console.ReadLine();
            }
            foreach (var kvp in courseInfo)
            {
                int cnt = 0;

                foreach (var cnts in kvp.Value)
                {
                    cnt++;
                }

                Console.WriteLine($"{kvp.Key}: {cnt}");

                foreach (var course in kvp.Value)
                {
                    Console.WriteLine($"-- {course}");
                }
            }
        }
    }
}
