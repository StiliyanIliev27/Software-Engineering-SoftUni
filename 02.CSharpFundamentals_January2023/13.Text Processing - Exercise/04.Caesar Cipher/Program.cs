using System.Text;

namespace _04.Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder newText = new StringBuilder();
            foreach (char oldCh in text)
            {
                char newCh = (char)(oldCh + 3);
                newText.Append(newCh);
            }
            Console.WriteLine(newText);
        }
    }
}
