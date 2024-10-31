namespace _01.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ");
            List<string> validNames = new List<string>();

            foreach (var name in names)
            {
                if (name.Length >= 3 && name.Length <= 16) // "Jeff"
                {
                    bool isValid = true;
                    for (int i = 0; i < name.Length; i++)
                    {
                        char currentCh = name[i]; // 'J'

                        if (!(currentCh == '-' || currentCh == '_' ||
                            char.IsLetter(currentCh) || char.IsDigit(currentCh)))
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        validNames.Add(name);
                    }
                }
            }
            Console.WriteLine(String.Join(Environment.NewLine, validNames));
        }
    }
}
