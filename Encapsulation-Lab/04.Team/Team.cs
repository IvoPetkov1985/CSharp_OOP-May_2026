using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public IReadOnlyCollection<Person> FirstTeam
        {
            get
            {
                return firstTeam.AsReadOnly();
            }
        }

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get
            {
                return reserveTeam.AsReadOnly();
            }
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new();
            builder.AppendLine($"First team has {FirstTeam.Count} players.");
            builder.AppendLine($"Reserve team has {ReserveTeam.Count} players.");
            return builder.ToString().TrimEnd();
        }
    }
}
