namespace _03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //This exercise gets 50 out of 100 points in SoftUni's Judge System.

            int n = int.Parse(Console.ReadLine());

            List<string> guestList = new List<string>();
            string[] command = new string[] { };

            bool isOnTheList = false;

            for (int i = 0; i < n; i++)
            {
                command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (guestList.Contains(command[0]))
                {
                    isOnTheList = true;
                }


                if (command.Length == 3)
                {
                    if (isOnTheList)
                    {
                        Console.WriteLine($"{command[0]} is already in the list!");
                    }
                    else
                    {
                        guestList.Add(command[0]);
                    }
                }
                else
                {
                    if (isOnTheList)
                    {
                        guestList.Remove(command[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{command[0]} is not in the list!");
                    }
                }

            }

            Console.WriteLine(String.Join(Environment.NewLine, guestList));
        }
    }
}
