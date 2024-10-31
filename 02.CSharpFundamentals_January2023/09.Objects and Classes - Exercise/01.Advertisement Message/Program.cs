namespace _01.Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = { "Excellent product.", "Such a great product.", "I always use that product.",
                "Best product of its category.", "Exceptional product.", "I can't live without this product." };

            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Random random = new Random();

                int randomIndexPhrases = random.Next(1, phrases.Length);
                string randomWordPhrase = phrases[randomIndexPhrases];

                int randomIndexEvents = random.Next(1, events.Length);
                string randomWordEvents = events[randomIndexEvents];

                int randomIndexAuthors = random.Next(1, authors.Length);
                string randomWordAuthors = authors[randomIndexAuthors];

                int randomIndexCities = random.Next(1, cities.Length);
                string randomWordCities = cities[randomIndexCities];

                Console.WriteLine($"{randomWordPhrase} {randomWordEvents} {randomWordAuthors} – {randomWordCities}.");
            }
        }
    }
}
