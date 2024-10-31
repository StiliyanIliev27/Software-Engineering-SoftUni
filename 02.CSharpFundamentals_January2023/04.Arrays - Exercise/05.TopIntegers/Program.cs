namespace _05.TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine() // 1, 4, 3, 2 => 4
                .Split()
                .Select(int.Parse)
                .ToArray();



            for (int i = 0; i < integers.Length; i++)
            {
                bool isTop = true;

                for (int j = i + 1; j < integers.Length; j++)
                {
                    if (integers[i] <= integers[j])
                    {
                        isTop = false;
                        break;
                    }
                }
                if (isTop)
                {
                    Console.Write(integers[i] + " ");
                }
            }
        }
    }
}
