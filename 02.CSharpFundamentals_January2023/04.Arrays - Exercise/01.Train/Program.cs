namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] wagons = new int[n];

            int sum = 0;

            for (int i = 0; i < wagons.Length; i++)
            {
                int people = int.Parse(Console.ReadLine());
                wagons[i] = people;
                sum += people;

            }

            Console.WriteLine(String.Join(" ", wagons));
            Console.WriteLine(sum);
        }
    }
}
