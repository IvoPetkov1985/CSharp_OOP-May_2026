namespace _04.Students
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
                string city = studentInfo[3];

                Student student = new(firstName, lastName, age, city);
                students.Add(student);

                inputLine = Console.ReadLine();
            }

            string searchedCity = Console.ReadLine();

            foreach (Student student in students.Where(s => s.HomeTown == searchedCity))
            {
                Console.WriteLine(student.ToString());
            }
        }
    }

    class Student
    {
        public Student(string fName, string lName, int age, string homeTown)
        {
            FirstName = fName;
            LastName = lName;
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
