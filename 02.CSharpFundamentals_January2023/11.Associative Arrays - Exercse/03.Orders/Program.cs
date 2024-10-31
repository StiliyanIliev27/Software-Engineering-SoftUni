namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, double[]> purchasedProducts = new Dictionary<string, double[]>();

            while (command != "buy")
            {
                string[] product = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string productName = product[0];
                double price = double.Parse(product[1]);
                double quantity = double.Parse(product[2]);

                if (!purchasedProducts.ContainsKey(productName))
                {
                    purchasedProducts[productName] = new double[2];
                }

                purchasedProducts[productName][0] = price;
                purchasedProducts[productName][1] += quantity;

                command = Console.ReadLine();
            }
            foreach (var product in purchasedProducts)
            {
                double totalPrice = product.Value[0] * product.Value[1];

                Console.WriteLine($"{product.Key} -> {totalPrice:f2}");
            }
        }
    }
}
