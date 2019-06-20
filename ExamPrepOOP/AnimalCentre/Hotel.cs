using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace AnimalCentre.Models.Hotels
{
    public class Hotel : IHotel
    { 
        private readonly Dictionary<string, IAnimal> animals;
        private int capacity;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
            this.capacity = 10;
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => this.animals.ToImmutableDictionary();

        public void Accommodate(IAnimal animal) 
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Not enough capacity");
            }

            if (!this.animals.ContainsKey(animal.Name))
            {
                this.animals[animal.Name] = animal;
                capacity--;
            }
            else
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
        }

        public void Adopt(string animalName, string owner)
        {
            if (this.animals.ContainsKey(animalName))
            {
                IAnimal animal = this.animals[animalName];
                animal.IsAdopt = true;
                animal.Owner = owner;
                this.animals.Remove(animalName);
                capacity++;
            }
            else
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
        }
    }
}
