namespace _02.OldestFamilyMember
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int membersCount = int.Parse(Console.ReadLine());
            Family family = new();

            for (int i = 0; i < membersCount; i++)
            {
                string[] personData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personData[0];
                int age = int.Parse(personData[1]);
                Person person = new(name, age);
                family.AddMember(person);
            }

            Person searchedPerson = family.GetOldestMember();

            if (searchedPerson != null)
            {
                Console.WriteLine(searchedPerson.ToString());
            }

        }
    }
    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }

    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }

        public ICollection<Person> People { get; set; }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldest = People
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();
            return oldest;
        }
    }
}
