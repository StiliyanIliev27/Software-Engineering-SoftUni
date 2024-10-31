namespace _02.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Console.WriteLine(MultiplierMethod(input[0], input[1]));
        }
        static int MultiplierMethod(string firstStr, string secondStr)
        {
            int sum = 0;
            string shortestStr = string.Empty;
            string longestStr = string.Empty;

            if (firstStr.Length > secondStr.Length)
            {
                longestStr = firstStr;
                shortestStr = secondStr;
            }
            else
            {
                longestStr = secondStr;
                shortestStr = firstStr;
            }

            for (int i = 0; i < shortestStr.Length; i++)
            {
                sum += shortestStr[i] * longestStr[i];
            }
            for (int i = shortestStr.Length; i < longestStr.Length; i++)
            {
                sum += longestStr[i];
            }
            return sum;
        }
    }
}
