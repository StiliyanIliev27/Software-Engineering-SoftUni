namespace _02._Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];
            int lastNumber = 1;

            for (int i = 0; i < 10; i++)
            {
                string stringNumber = Console.ReadLine();
                int numericValue = 0;

                var isNumber = int.TryParse(stringNumber, out numericValue);

                numbers[i] = numericValue;

                if (i > 0)
                {
                    lastNumber = numbers[i - 1];
                }
                try
                {
                    if (!isNumber)
                    {
                        i--;
                        throw new ArgumentException("Invalid Number!");
                    }

                    if (numericValue < 2 || numericValue > 98 || numericValue < lastNumber)
                    {
                        i--;

                        throw new ArgumentException($"Your number is not in range {lastNumber} - 100!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
