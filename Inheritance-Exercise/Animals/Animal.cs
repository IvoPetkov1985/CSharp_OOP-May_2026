using System;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public int age;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                age = value;
            }
        }

        public string Gender { get; set; }

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
