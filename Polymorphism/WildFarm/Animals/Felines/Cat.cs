using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Mammal;
using WildFarm.Foods;

namespace WildFarm.Animals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Meat || food is Vegetable)
            {
                this.Weight += (food.Quantity * 0.30);
                this.FoodEaten += food.Quantity;
            }

            else
            {
                throw new ArgumentException($"Cat does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
