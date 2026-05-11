namespace _01.AdvertisementMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product." };
            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int messagesCount = int.Parse(Console.ReadLine());

            Random random = new();

            for (int i = 0; i < messagesCount; i++)
            {
                int phraseIndex = random.Next(0, phrases.Length);
                int eventIndex = random.Next(0, events.Length);
                int authorIndex = random.Next(0, authors.Length);
                int citiesIndex = random.Next(0, cities.Length);

                string randomPhrase = phrases[phraseIndex];
                string randomEvent = events[eventIndex];
                string randomAuthor = authors[authorIndex];
                string randomCity = cities[citiesIndex];

                Console.WriteLine($"{randomPhrase} {randomEvent} {randomAuthor} – {randomCity}.");
            }
        }
    }
}
