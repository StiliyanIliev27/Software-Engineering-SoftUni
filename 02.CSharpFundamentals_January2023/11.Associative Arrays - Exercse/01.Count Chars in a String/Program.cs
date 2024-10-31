namespace _01.Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();

            Dictionary<char, int> occurences = new Dictionary<char, int>();

            foreach (char input in words)
            {
                if (input == ' ')
                {
                    continue;
                }

                if (!occurences.ContainsKey(input))
                {
                    occurences.Add(input, 0);
                }
                occurences[input]++;
            }
            foreach (var letter in occurences)
            {
                Console.WriteLine($"{letter.Key} -> " + string.Join(" ", letter.Value));
            }
        }
    }
}
