using System.Text;

namespace _05.TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());

            List<Team> teams = new();

            for (int i = 0; i < teamsCount; i++)
            {
                string[] teamTokens = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);
                string creatorName = teamTokens[0];
                string teamName = teamTokens[1];

                if (teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Any(t => t.Creator == creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                    continue;
                }

                Team team = new(teamName, creatorName);
                teams.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
            }

            string inputLine = Console.ReadLine();

            while (inputLine != "end of assignment")
            {
                string[] tokens = inputLine
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);
                string username = tokens[0];
                string teamName = tokens[1];

                if (!teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    inputLine = Console.ReadLine();
                    continue;
                }

                Team team = teams.First(t => t.Name == teamName);

                if (teams.Any(t => t.Members.Contains(username)) ||
                    team.Creator == username)
                {
                    Console.WriteLine($"Member {username} cannot join team {teamName}!");
                    inputLine = Console.ReadLine();
                    continue;
                }

                team.Members.Add(username);

                inputLine = Console.ReadLine();
            }

            List<Team> validTeams = teams
                .FindAll(t => t.Members.Count > 0)
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.Name)
                .ToList();

            List<Team> invalidTeams = teams
                .FindAll(t => t.Members.Count == 0)
                .OrderBy(t => t.Name)
                .ToList();

            foreach (Team team in validTeams)
            {
                Console.WriteLine(team);
            }

            Console.WriteLine("Teams to disband:");

            foreach (Team team in invalidTeams)
            {
                Console.WriteLine(team.Name);
            }
        }
    }

    class Team
    {
        public Team(string teamName, string creator)
        {
            Name = teamName;
            Creator = creator;
            Members = new List<string>();
        }

        public string Name { get; set; } = string.Empty;

        public string Creator { get; set; } = string.Empty;

        public IList<string> Members { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new();
            builder.AppendLine(Name);
            builder.AppendLine($"- {Creator}");

            foreach (string member in Members.OrderBy(m => m))
            {
                builder.AppendLine($"-- {member}");
            }

            return builder.ToString().TrimEnd();
        }
    }
}
