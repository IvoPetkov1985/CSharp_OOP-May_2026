namespace _05.Students2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            List<Student> students = new();

            while (inputLine != "end")
            {
                string[] studentInfo = inputLine
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                int age = int.Parse(studentInfo[2]);
                string town = studentInfo[3];

                Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

                if (student == null)
                {
                    student = new(firstName, lastName, age, town);
                    students.Add(student);
                }
                else
                {
                    student.Age = age;
                    student.HomeTown = town;
                }

                inputLine = Console.ReadLine();
            }

            string searchedTown = Console.ReadLine();

            Console.WriteLine(string.Join(Environment.NewLine, students
                .Where(s => s.HomeTown == searchedTown)
                .Select(s => s.ToString())));
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }
    }
}
