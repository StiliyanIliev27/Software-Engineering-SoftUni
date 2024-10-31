namespace P04.Print_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine()!);
            int end = int.Parse(Console.ReadLine()!);

            int cnt = 0;

            for (int i = start; i <= end; i++)
            {
                Console.Write($"{i} ");
                cnt += i;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {cnt}");
        }
    }
}
