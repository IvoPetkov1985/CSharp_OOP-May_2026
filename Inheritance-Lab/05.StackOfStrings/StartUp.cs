namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings strings = new();
            strings.AddRange(new string[] { "1914", "May", "24" });
            Console.WriteLine(string.Join("-", strings));
            Console.WriteLine(strings.IsEmpty());
            Console.WriteLine(strings.Count);
        }
    }
}
