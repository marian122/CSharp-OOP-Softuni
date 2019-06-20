using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();


            while (true)
            {
                string animal = Console.ReadLine();

                if (animal == "Beast!")
                {
                    foreach (var beast in animals)
                    {
                        Console.WriteLine(beast);
                    }
                    break;
                }


                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);
                var gender = input[2];


                try
                {
                    if (animal == "Cat")
                    {
                        animals.Add(new Cat(name, age, gender));

                    }

                    else if (animal == "Dog")
                    {
                        animals.Add(new Dog(name, age, gender));
                    }

                    else if (animal == "Frog")
                    {
                        animals.Add(new Frog(name, age, gender));
                    }

                    else if (animal == "Kitten")
                    {
                        animals.Add(new Kitten(name, age));
                    }
                    else if (animal == "Tomcat")
                    {
                        animals.Add(new Tomcat(name, age));
                    }

                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
