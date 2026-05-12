namespace _05.ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> clientsList = new();
            List<Product> productsList = new();

            string clientsLine = Console.ReadLine();
            string[] clients = clientsLine
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (string clientRow in clients)
            {
                string[] clientData = clientRow
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = clientData[0];
                decimal money = decimal.Parse(clientData[1]);
                Person client = new(name, money);
                clientsList.Add(client);
            }

            string productsLine = Console.ReadLine();
            string[] products = productsLine
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (string productRow in products)
            {
                string[] productData = productRow
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = productData[0];
                decimal price = decimal.Parse(productData[1]);
                Product product = new(name, price);
                productsList.Add(product);
            }

            string commandLine = Console.ReadLine();

            while (commandLine != "END")
            {
                string[] tokens = commandLine
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = tokens[0];
                string productName = tokens[1];

                Person client = clientsList.First(p => p.Name == personName);
                Product product = productsList.First(p => p.Name == productName);
                client.AddProductToBag(product);

                commandLine = Console.ReadLine();
            }

            foreach (Person client in clientsList)
            {
                Console.WriteLine(client.ToString());
            }
        }
    }

    public class Person
    {
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

        public string Name { get; set; }

        public decimal Money { get; set; }

        public ICollection<Product> BagOfProducts { get; set; }

        public void AddProductToBag(Product product)
        {
            if (product.Cost <= Money)
            {
                BagOfProducts.Add(product);
                Money -= product.Cost;
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            string boughtProducts = string.Empty;

            if (BagOfProducts.Count > 0)
            {
                boughtProducts = string
                    .Join(", ", BagOfProducts.Select(p => p.Name));
            }
            else
            {
                boughtProducts = "Nothing bought";
            }

            return $"{Name} - {boughtProducts}";
        }
    }

    public class Product
    {
        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; set; }

        public decimal Cost { get; set; }
    }
}
