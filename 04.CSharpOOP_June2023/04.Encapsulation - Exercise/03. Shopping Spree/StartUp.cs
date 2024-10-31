namespace P03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] nameAndMoneyPerson = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new();
            List<Product> products = new();

            try
            {
                foreach (var input in nameAndMoneyPerson)
                {
                    string[] splittedInput = input.Split("=", StringSplitOptions.RemoveEmptyEntries);

                    string name = splittedInput[0];
                    decimal money = decimal.Parse(splittedInput[1]);

                    Person person = new(name, money);
                    people.Add(person);
                }

                string[] nameAndCostProduct = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var input in nameAndCostProduct)
                {
                    string[] splittedInput = input.Split("=", StringSplitOptions.RemoveEmptyEntries);

                    string name = splittedInput[0];
                    decimal cost = decimal.Parse(splittedInput[1]);

                    Product product = new(name, cost);
                    products.Add(product);
                }

                string command = Console.ReadLine();
                while(command != "END")
                {
                    string[] commandInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    
                    string nameOfPerson = commandInfo[0];
                    string nameOfProduct = commandInfo[1];

                    Person person = people.FirstOrDefault(p => p.Name == nameOfPerson);
                    Product product = products.FirstOrDefault(p => p.Name == nameOfProduct);

                    if (person.Money >= product.Cost)
                    {
                        person.Products.Add(product);
                        Console.WriteLine($"{nameOfPerson} bought {nameOfProduct}");
                        person.Money -= product.Cost;
                    }
                    else
                    {
                        Console.WriteLine($"{nameOfPerson} can't afford {nameOfProduct}");
                    }
                    
                    command = Console.ReadLine();
                }
                foreach(var person in people)
                {
                    if (person.Products.Any())
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.Select(x => x.Name))}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                }
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            
        }
    }
}