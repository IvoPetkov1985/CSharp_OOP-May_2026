namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new();
            int randomIndex = random.Next(0, this.Count);
            string randomString = this[randomIndex];
            this.RemoveAt(randomIndex);
            return randomString;
        }
    }
}
