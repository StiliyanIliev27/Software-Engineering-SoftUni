namespace _03.Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstLine = new int[n];
            int[] secondLine = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] currentInput = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int currentRow = i;

                if (currentRow % 2 == 0)
                {
                    firstLine[currentRow] = currentInput[0];
                    secondLine[currentRow] = currentInput[1];
                }
                else
                {
                    firstLine[currentRow] = currentInput[1];
                    secondLine[currentRow] = currentInput[0];
                }
            }

            Console.WriteLine(string.Join(" ", firstLine));
            Console.WriteLine(string.Join(" ", secondLine));
        }
    }
}
