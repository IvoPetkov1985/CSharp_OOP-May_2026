using System.Text;

namespace _06.StoreBoxes.v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            List<Box> boxes = new();

            while (inputLine != "end")
            {
                string[] boxTokens = inputLine
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string serialnumber = boxTokens[0];
                string itemName = boxTokens[1];
                int itemsQuantity = int.Parse(boxTokens[2]);
                decimal itemPrice = decimal.Parse(boxTokens[3]);

                Item item = new(itemName, itemPrice);
                Box box = new(serialnumber, item, itemsQuantity);
                boxes.Add(box);

                inputLine = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, boxes
                .OrderByDescending(b => b.BoxPrice)
                .Select(b => b.ToString())));
        }        
    }

    class Item
    {
        public Item(string name, decimal price)
        {
            Name = name;
            ItemPrice = price;
        }

        public string Name { get; set; }

        public decimal ItemPrice { get; set; }
    }

    class Box
    {
        public Box(string serialNumber, Item item, int itemsQuantity)
        {
            SerialNumber = serialNumber;
            ItemsQuantity = itemsQuantity;
            Item = item;
        }

        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int ItemsQuantity { get; set; }

        public decimal BoxPrice => Item.ItemPrice * ItemsQuantity;

        public override string ToString()
        {
            StringBuilder builder = new();
            builder.AppendLine(SerialNumber);
            builder.AppendLine($"-- {Item.Name} - ${Item.ItemPrice:F2}: {ItemsQuantity}");
            builder.AppendLine($"-- ${BoxPrice:F2}");
            return builder.ToString().TrimEnd();
        }
    }
}
