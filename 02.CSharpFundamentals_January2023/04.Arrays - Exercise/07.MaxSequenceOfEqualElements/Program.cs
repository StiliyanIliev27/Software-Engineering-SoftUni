namespace _07.MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int longestSequenceStartIndex = 0;
            int longestSequenceLength = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                int currentSequenceStartIndex = i - 1;
                int currentSequenceLength = 1;

                while (i < numbers.Length && numbers[i] == numbers[i - 1])
                {
                    currentSequenceLength++;
                    i++;
                }

                if (currentSequenceLength > longestSequenceLength)
                {
                    longestSequenceLength = currentSequenceLength;
                    longestSequenceStartIndex = currentSequenceStartIndex;
                }

            }

            for (int j = longestSequenceStartIndex;
                j < longestSequenceStartIndex + longestSequenceLength; j++)
            {
                Console.Write(numbers[j] + " ");
            }
        }
    }
}
