using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Factories
{
    public static class FoodFactory
    {
        public static Food CreateFood(string type, int quantity)
        {
            type = type.ToLower();

            switch (type)
            {
                case "fruit":
                    return new Fruit(quantity);

                case "vegetable":
                    return new Vegetable(quantity);

                case "seeds":
                    return new Seeds(quantity);

                case "meat":
                    return new Meat(quantity);

                default:
                    throw new ArgumentException("Invalid food type!");

            }
        }
        
    }
}
