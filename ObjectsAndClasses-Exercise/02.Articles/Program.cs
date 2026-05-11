namespace _02.Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] articleTokens = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string title = articleTokens[0];
            string content = articleTokens[1];
            string author = articleTokens[2];
            Article article = new(title, content, author);

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandTokens = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandTokens[0];
                string value = commandTokens[1];

                if (command == "Edit")
                {
                    article.Edit(value);
                }
                else if (command == "ChangeAuthor")
                {
                    article.ChangeAuthor(value);
                }
                else if (command == "Rename")
                {
                    article.Rename(value);
                }
            }

            Console.WriteLine(article);
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

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
