namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            Student[] students = new Student[studentsCount];
            
            for (int i = 0; i < studentsCount; i++)
            {
                string[] studentTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstName = studentTokens[0];
                string lastName = studentTokens[1];
                double grade = double.Parse(studentTokens[2]);

                Student student = new(firstName, lastName, grade);
                students[i] = student;
            }

            students = students.OrderByDescending(s => s.Grade).ToArray();

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }
    }
}
