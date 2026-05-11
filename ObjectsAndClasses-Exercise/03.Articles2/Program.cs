namespace _03.Articles2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());

            Article[] articles = new Article[numberOfArticles];

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] articleTokens = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string title = articleTokens[0];
                string content = articleTokens[1];
                string author = articleTokens[2];
                Article article = new(title, content, author);
                articles[i] = article;
            }

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
