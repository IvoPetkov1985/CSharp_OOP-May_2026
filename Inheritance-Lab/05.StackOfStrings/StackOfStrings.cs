namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (Count > 0)
            {
                return false;
            }

            return true;
        }

        public Stack<string> AddRange(IEnumerable<string> strings)
        {
            foreach (string entry in strings)
            {
                Push(entry);
            }

            return this;
        }
    }
}
