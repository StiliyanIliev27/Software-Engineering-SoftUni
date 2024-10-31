using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"^>>(?<furnitureName>[A-Za-z]+)<<(?<price>\d+(\.\d+)?)!(?<quantity>\d+)(\.\d+){0,1}$";
            double totalPrice = 0.0;
            double totalIncome = 0.0;
            List<string> furnitures = new List<string>();

            while (input != "Purchase")
            {
                Regex regex = new Regex(pattern);
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string furnitureName = match.Groups["furnitureName"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    totalPrice = price * quantity;
                    totalIncome += totalPrice;
                    furnitures.Add(furnitureName);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            foreach (string furnitureName in furnitures)
            {
                Console.WriteLine(string.Join(Environment.NewLine, furnitureName));
            }
            Console.WriteLine($"Total money spend: {totalIncome:f2}");
        }
    }
}
