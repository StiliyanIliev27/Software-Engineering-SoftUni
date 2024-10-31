namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string use = "";
            int cnt = 1;

            foreach (var word in username.Split(' '))
            {
                string temp = "";
                foreach (var ch in word.ToCharArray())
                {
                    temp = ch + temp;
                }
                use = use + temp + "";
            }

            for (int i = 1; i <= int.MaxValue; i++)
            {
                string words = Console.ReadLine();

                if (words == use)
                {
                    Console.WriteLine($"User {username} logged in.");
                    return;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
                if (cnt == 3)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
                cnt++;
            }
        }
    }
}
