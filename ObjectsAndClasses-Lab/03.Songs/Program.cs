namespace _03.Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int songsCount = int.Parse(Console.ReadLine());
            Song[] songs = new Song[songsCount];

            for (int i = 0; i < songsCount; i++)
            {
                string[] songInfo = Console.ReadLine()
                    .Split("_", StringSplitOptions.RemoveEmptyEntries);
                string typeList = songInfo[0];
                string songName = songInfo[1];
                string duration = songInfo[2];

                Song song = new Song();
                song.TypeList = typeList;
                song.Name = songName;
                song.Time = duration;
                songs[i] = song;
            }

            string searchedType = Console.ReadLine();

            if (searchedType == "all")
            {
                Console.WriteLine(string.Join(Environment.NewLine, songs
                    .Select(s => s.Name)));
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, songs
                    .Where(s => s.TypeList == searchedType)
                    .Select(s => s.Name)));
            }
        }
    }

    class Song
    {
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }
}
