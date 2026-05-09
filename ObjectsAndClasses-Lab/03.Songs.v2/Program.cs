namespace _03.Songs.v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int songsCount = int.Parse(Console.ReadLine());
            HashSet<Song> playlist = new();

            for (int i = 0; i < songsCount; i++)
            {
                string inputLine = Console.ReadLine();
                string[] songInfo = inputLine
                    .Split("_", StringSplitOptions.RemoveEmptyEntries);
                string typeList = songInfo[0];
                string songName = songInfo[1];
                string duration = songInfo[2];

                Song song = new(typeList, songName, duration);
                playlist.Add(song);
            }

            string searchedType = Console.ReadLine();

            if (searchedType == "all")
            {
                foreach (Song song in playlist)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in playlist.Where(s => s.TypeList == searchedType))
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }

    class Song
    {
        public Song(string typeList, string name, string duration)
        {
            TypeList = typeList;
            Name = name;
            Duration = duration;
        }

        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Duration { get; set; }
    }
}
