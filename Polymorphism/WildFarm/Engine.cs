using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals;
using WildFarm.Factories;

namespace WildFarm
{
    public class Engine
    {
        public void Run()
        {
            var animals = new List<Animal>();

            var animalInfo = Console.ReadLine().Split();

            while (animalInfo[0] != "End")
            {
                Animal animal = AnimalFactory.CreateAnimal(animalInfo);

                animals.Add(animal);

                var foodInfo = Console.ReadLine().Split();
                var type = foodInfo[0];
                var quantity = int.Parse(foodInfo[1]);

                Food food = FoodFactory.CreateFood(type, quantity);

                try
                {
                    animal.ProduceSound();
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
                animalInfo = Console.ReadLine().Split();
            }

            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
        }
    }
}
