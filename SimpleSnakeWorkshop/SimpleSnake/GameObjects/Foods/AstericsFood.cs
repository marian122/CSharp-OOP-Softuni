using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class AstericsFood : Food
    {
        private const string FoodSymbol = "*";
        private const int FoodPoints = 1;


        public AstericsFood(Coordinate coordinate) 
            : base(FoodSymbol, FoodPoints, coordinate)
        {
        }
    }
}
