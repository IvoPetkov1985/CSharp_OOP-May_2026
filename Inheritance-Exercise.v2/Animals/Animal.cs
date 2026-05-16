using System;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private const string ErrorMessage = "Invalid input!";

        private string name;
        private int age;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ErrorMessage);
                }

                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ErrorMessage);
                }

                age = value;
            }
        }

        public string Gender
        {
            get { return gender; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ErrorMessage);
                }

                gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            StringBuilder builder = new();
            builder.AppendLine(GetType().Name);
            builder.AppendLine($"{Name} {Age} {Gender}");
            builder.AppendLine(ProduceSound());
            return builder.ToString().TrimEnd();
        }
    }
}
