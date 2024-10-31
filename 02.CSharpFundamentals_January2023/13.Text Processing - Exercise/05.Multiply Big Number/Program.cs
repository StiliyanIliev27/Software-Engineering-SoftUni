using System.Text;

namespace _05.Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNum = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            if (bigNum == "0" || number == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int reminder = 0;
            for (int i = bigNum.Length - 1; i >= 0; i--)
            {
                char currentDigitAsChar = bigNum[i]; // '4'
                int currentDigit = int.Parse(currentDigitAsChar.ToString()); // 4
                int product = currentDigit * number + reminder;
                int result = product % 10;
                reminder = product / 10;
                sb.Insert(0, result);
            }

            if (reminder > 0)
            {
                sb.Insert(0, reminder);
            }
            Console.WriteLine(sb);
        }
    }
}
