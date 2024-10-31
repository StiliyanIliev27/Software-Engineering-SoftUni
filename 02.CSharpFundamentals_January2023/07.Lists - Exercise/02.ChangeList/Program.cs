namespace _02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandInfo = command.Split().ToArray();
                string commandType = commandInfo[0];
                int element = int.Parse(commandInfo[1]);

                if (commandType == "Insert")
                {
                    int position = int.Parse(commandInfo[2]);
                    integers.Insert(position, element);
                }
                else if (commandType == "Delete")
                {
                    integers.RemoveAll(x => x == element);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", integers));
        }
    }
}
