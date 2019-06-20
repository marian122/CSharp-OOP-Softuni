using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Mammal;
using WildFarm.Foods;

namespace WildFarm.Animals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                this.Weight += (food.Quantity * 1);
                this.FoodEaten += food.Quantity;
            }

            else
            {
                throw new ArgumentException($"Tiger does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
