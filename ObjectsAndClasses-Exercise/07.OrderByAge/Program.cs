namespace _07.OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            ICollection<Person> persons = new HashSet<Person>();

            while (inputLine != "End")
            {
                string[] personData = inputLine
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personData[0];
                string id = personData[1];
                int age = int.Parse(personData[2]);

                Person person = persons.FirstOrDefault(p => p.ID == id);

                if (person == null)
                {
                    person = new(name, id, age);
                    persons.Add(person);
                }
                else
                {
                    person.Name = name;
                    person.Age = age;
                }

                inputLine = Console.ReadLine();
            }

            foreach (Person person in persons.OrderBy(p => p.Age))
            {
                Console.WriteLine(person);
            }
        }
    }

    class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }

        public string Name { get; set; } = string.Empty;

        public string ID { get; set; } = string.Empty;

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
