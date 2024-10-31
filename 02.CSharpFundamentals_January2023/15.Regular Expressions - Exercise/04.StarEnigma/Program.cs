using System.Text.RegularExpressions;
using System.Text;

namespace _04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\@(?<planet>[A-Za-z]+)[^\@\-\!\:\>]*?\:\d+[^\@\-\!\:\>]*?\!(?<attackType>A|D)\![^\@\-\!\:\>]*?\-\>\d+";
            Regex regex = new Regex(pattern);
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string encryptedMessage = Console.ReadLine();
                string decryptedMessage = DecryptMessage(encryptedMessage);
                Match match = regex.Match(decryptedMessage);
                if (match.Success)
                {
                    string planet = match.Groups["planet"].Value;
                    string attackType = match.Groups["attackType"].Value;

                    if (attackType == "A")
                    {
                        attackedPlanets.Add(planet);
                    }
                    else if (attackType == "D")
                    {
                        destroyedPlanets.Add(planet);
                    }
                }
            }
            PrintMessage(attackedPlanets, "Attacked");
            PrintMessage(destroyedPlanets, "Destroyed");
        }

        static void PrintMessage(List<string> planets, string attackType)
        {
            Console.WriteLine($"{attackType} planets: {planets.Count}");
            foreach (string planet in planets.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
        static string DecryptMessage(string encryptedMessage)
        {
            StringBuilder decryptedMessage = new StringBuilder();
            int decryptionStep = GetDecryptionMessage(encryptedMessage);
            foreach (char oldCh in encryptedMessage)
            {
                decryptedMessage.Append((char)(oldCh - decryptionStep));
            }
            return decryptedMessage.ToString();
        }
        static int GetDecryptionMessage(string encryptedMessage)
        {
            int decryptionStep = 0;
            foreach (char ch in encryptedMessage.ToLower())
            {
                if (ch == 's' || ch == 't' || ch == 'a' || ch == 'r')
                {
                    decryptionStep++;
                }
            }
            return decryptionStep;
        }
    }
}
