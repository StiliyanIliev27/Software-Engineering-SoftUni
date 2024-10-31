namespace P01.Ages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int.TryParse(Console.ReadLine(), out int number);

            switch (number)
            {
                case >= 0 and <= 2:
                    Console.WriteLine("baby");
                    break;
                case >= 3 and <= 13:
                    Console.WriteLine("child");
                    break;
                case >= 14 and <= 19:
                    Console.WriteLine("teenager");
                    break;
                case >= 20 and <= 65:
                    Console.WriteLine("adult");
                    break;
                case >= 66:
                    Console.WriteLine("elder");
                    break;

            }
        }
    }
}
