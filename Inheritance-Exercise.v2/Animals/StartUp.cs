using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animalType = Console.ReadLine();

            while (animalType != "Beast!")
            {
                string[] animalTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = animalTokens[0];
                int age = int.Parse(animalTokens[1]);
                string gender = animalTokens[2];

                try
                {
                    if (animalType == "Dog")
                    {
                        Dog dog = new(name, age, gender);
                        Console.WriteLine(dog);
                    }
                    else if (animalType == "Frog")
                    {
                        Frog frog = new(name, age, gender);
                        Console.WriteLine(frog);
                    }
                    else if (animalType == "Cat")
                    {
                        Cat cat = new(name, age, gender);
                        Console.WriteLine(cat);
                    }
                    else if (animalType == "Kitten")
                    {
                        Kitten kitten = new(name, age);
                        Console.WriteLine(kitten);
                    }
                    else if (animalType == "Tomcat")
                    {
                        Tomcat tomcat = new(name, age);
                        Console.WriteLine(tomcat);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animalType = Console.ReadLine();
            }
        }
    }
}
