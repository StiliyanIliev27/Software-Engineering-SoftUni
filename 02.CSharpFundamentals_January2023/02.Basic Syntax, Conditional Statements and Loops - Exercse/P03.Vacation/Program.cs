namespace P03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine()!);
            string typeOfTheGroup = Console.ReadLine()!;
            string day = Console.ReadLine()!;

            decimal price = 0;
            decimal firstPercPrice = 0;
            decimal percentagePrice = 0;

            if (typeOfTheGroup == "Students")
            {
                if (day == "Friday")
                {
                    price = countOfPeople * 8.45m;
                }
                if (day == "Saturday")
                {
                    price = countOfPeople * 9.80m;
                }
                if (day == "Sunday")
                {
                    price = countOfPeople * 10.46m;
                }
                if (countOfPeople >= 30)
                {
                    firstPercPrice = price * 0.15m;
                    percentagePrice = price - firstPercPrice;
                    price = percentagePrice;
                }
            }
            else if (typeOfTheGroup == "Business")
            {
                if (countOfPeople >= 100)
                {
                    countOfPeople -= 10;
                }
                if (day == "Friday")
                {
                    price = countOfPeople * 10.90m;
                }
                if (day == "Saturday")
                {
                    price = countOfPeople * 15.60m;
                }
                if (day == "Sunday")
                {
                    price = countOfPeople * 16m;
                }

            }
            else if (typeOfTheGroup == "Regular")
            {
                if (day == "Friday")
                {
                    price = countOfPeople * 15m;
                }
                if (day == "Saturday")
                {
                    price = countOfPeople * 20m;
                }
                if (day == "Sunday")
                {
                    price = countOfPeople * 22.50m;
                }
                if (countOfPeople >= 10 && countOfPeople <= 20)
                {
                    firstPercPrice = price * 0.05m;
                    percentagePrice = price - firstPercPrice;
                }
            }
            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
