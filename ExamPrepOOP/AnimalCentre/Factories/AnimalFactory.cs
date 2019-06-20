using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Factories
{
    public class AnimalFactory
    {
        public IAnimal CreateAnimal(string type, string name, int energy, int happiness, int playTime)
        {
            IAnimal newAnimal = null;
            switch (type)
            {
                case "Lion":
                    newAnimal = new Lion(name, energy, happiness, playTime);
                    break;
                case "Dog":
                    newAnimal = new Dog(name, energy, happiness, playTime);
                    break;
                case "Pig":
                    newAnimal = new Pig(name, energy, happiness, playTime);
                    break;
                case "Cat":
                    newAnimal = new Cat(name, energy, happiness, playTime);
                    break;
            }

            return newAnimal;
        }
    }
}
