using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

    }
}
