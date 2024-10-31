using System.Text;

namespace _08.Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries); // "A12b s17G"
            List<double> numbers = new List<double>();
            double value = 0.0;

            foreach (string word in text)// "A12b" -> first word
            {
                StringBuilder sb = new StringBuilder();
                bool went = false;

                for (int i = 0; i < word.Length; i++)
                {
                    char currentLetter = word[i]; //'A'
                    foreach (char ch in word)// "A12b" -> 'A', '1', '2', 'b'
                    {
                        if (char.IsDigit(ch))
                        {
                            sb.Append(ch);
                        }
                    }
                    int number = int.Parse(sb.ToString());

                    if (char.IsLetter(currentLetter))// Checking if is letter
                    {
                        int indexOfTheLetter = (int)currentLetter % 32;

                        if (!went)
                        {
                            if (currentLetter >= 'a' && currentLetter <= 'z')// Checking if the current letter is lowercase
                            {
                                value = (double)number * indexOfTheLetter;
                                went = true;
                            }
                            else if (currentLetter >= 'A' && currentLetter <= 'Z')// Checking else if the current letter is uppercase
                            {
                                value = (double)number / indexOfTheLetter;
                                went = true;
                            }
                        }
                        else
                        {
                            if (currentLetter >= 'a' && currentLetter <= 'z')// Checking if the current letter is lowercase
                            {
                                value += indexOfTheLetter;
                            }
                            else if (currentLetter >= 'A' && currentLetter <= 'Z')// Checking else if the current letter is uppercase
                            {
                                value -= indexOfTheLetter;
                            }
                        }
                    }
                    sb.Clear();
                }
                numbers.Add(value);
            }
            Console.WriteLine($"{numbers.Sum():f2}");
        }
    }
}
