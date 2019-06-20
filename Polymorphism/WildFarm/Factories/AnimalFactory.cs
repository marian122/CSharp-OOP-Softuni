using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Felines;
using WildFarm.Animals.Mammal;

namespace WildFarm.Factories
{
    public static class AnimalFactory
    {
        public static Animal CreateAnimal(string[] input)
        {
            string type = input[0].ToLower();

            switch (type)
            {
                case "owl":
                    return new Owl(input[1], double.Parse(input[2]), double.Parse(input[3]));

                case "hen":
                    return new Hen(input[1], double.Parse(input[2]), double.Parse(input[3]));

                case "mouse":
                    return new Mouse(input[1], double.Parse(input[2]), input[3]);

                case "cat":
                    return new Cat(input[1], double.Parse(input[2]), input[3], input[4]);

                case "dog":
                    return new Dog(input[1], double.Parse(input[2]), input[3]);

                case "tiger":
                    return new Tiger(input[1], double.Parse(input[2]), input[3], input[4]);

                default:
                    throw new ArgumentException($"{type} is not a valid Animal type.");
            }
        }
    }
}
