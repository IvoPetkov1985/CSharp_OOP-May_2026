namespace _06.StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            List<Box> boxes = new();

            while (inputLine != "end")
            {
                string[] tokens = inputLine
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string serialNumber = tokens[0];
                string itemName = tokens[1];
                int itemsQuantity = int.Parse(tokens[2]);
                decimal itemPrice = decimal.Parse(tokens[3]);

                Item item = new();
                item.Name = itemName;
                item.Price = itemPrice;

                Box box = new();
                box.SerialNumber = serialNumber;
                box.Item = item;
                box.ItemQuantity = itemsQuantity;
                box.BoxPrice = box.Item.Price * box.ItemQuantity;

                boxes.Add(box);

                inputLine = Console.ReadLine();
            }

            foreach (Box box in boxes.OrderByDescending(b => b.BoxPrice))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.BoxPrice:F2}");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }

        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int ItemQuantity { get; set; }

        public decimal BoxPrice { get; set; }
    }
}
