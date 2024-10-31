namespace P07.Ven_Mach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            decimal sum = 0m;

            decimal pricePerProduct = 0m;

            while (input != "Start")
            {
                if (input != "0.1" && input != "0.2" && input != "0.5" && input != "1" && input != "2")
                {
                    Console.WriteLine($"Cannot accept {input}");
                }
                if (input == "0.1" || input == "0.2" || input == "0.5" || input == "1" || input == "2")
                {
                    decimal coin = decimal.Parse(input);
                    sum += coin;
                }

                input = Console.ReadLine();

            }

            input = String.Empty;
            input = Console.ReadLine();

            while (input != "End")
            {
                switch (input)
                {
                    case "Nuts":
                        pricePerProduct = 2.0m;
                        if (sum - pricePerProduct >= 0)
                        {
                            Console.WriteLine("Purchased nuts");
                            sum -= pricePerProduct;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Water":
                        pricePerProduct = 0.7m;
                        if (sum - pricePerProduct >= 0)
                        {
                            Console.WriteLine("Purchased water");
                            sum -= pricePerProduct;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Crisps":
                        pricePerProduct = 1.5m;
                        if (sum - pricePerProduct >= 0)
                        {
                            Console.WriteLine("Purchased crisps");
                            sum -= pricePerProduct;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Soda":
                        pricePerProduct = 0.8m;
                        if (sum - pricePerProduct >= 0)
                        {
                            Console.WriteLine("Purchased soda");
                            sum -= pricePerProduct;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Coke":
                        pricePerProduct = 1.0m;
                        if (sum - pricePerProduct >= 0)
                        {
                            Console.WriteLine("Purchased coke");
                            sum -= pricePerProduct;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;

                }

                input = Console.ReadLine();
            }


            Console.WriteLine($"Change: {sum:f2}");
        }
    }
}
