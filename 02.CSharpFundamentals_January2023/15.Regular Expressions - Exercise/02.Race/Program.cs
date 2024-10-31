using System.Text.RegularExpressions;

namespace _02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine()
                 .Split(", ");
            Dictionary<string, int> personInfo = new Dictionary<string, int>();

            foreach (var participant in participants)
            {
                personInfo.Add(participant, 0);
            }

            string patternName = @"[\W\d]";
            string patternNumber = @"[\WA-Za-z]";
            string input = Console.ReadLine();

            while (input != "end of race")
            {
                string name = Regex.Replace(input, patternName, "");
                string number = Regex.Replace(input, patternNumber, "");
                int sum = 0;

                foreach (char digit in number)
                {
                    int currentDigit = int.Parse(digit.ToString());
                    sum += currentDigit;
                }

                if (personInfo.ContainsKey(name))
                {
                    personInfo[name] += sum;
                }
                input = Console.ReadLine();
            }

            int count = 1;
            foreach (var kvp in personInfo.OrderByDescending(x => x.Value))
            {
                string text = count == 1 ? "st" : count == 2 ? "nd" : "rd"; //A line which is equals to If - else if!!! 
                Console.WriteLine($"{count++}{text} place: {kvp.Key}");
                if (count == 4)
                {
                    break;
                }
            }
        }
    }
}
