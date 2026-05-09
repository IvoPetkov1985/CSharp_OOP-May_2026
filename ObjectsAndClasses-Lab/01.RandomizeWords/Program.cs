namespace _01.RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] wordsArray = Console.ReadLine()
                .Split(" ");

            Random random = new Random();

            for (int i = 0; i < wordsArray.Length; i++)
            {
                int randomIndex = random.Next(0, wordsArray.Length);
                string currentWord = wordsArray[i];
                wordsArray[i] = wordsArray[randomIndex];
                wordsArray[randomIndex] = currentWord;
            }

            Console.WriteLine(string.Join(Environment.NewLine, wordsArray));
        }
    }
}
