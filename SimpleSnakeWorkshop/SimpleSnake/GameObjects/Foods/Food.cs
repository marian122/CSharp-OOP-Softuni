using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food
    {
        protected Food(string symbol, int points, Coordinate coordinate)
        {
            this.Symbol = symbol;
            this.Points = points;
            this.Coordinate = coordinate;
        }

        public string Symbol { get; set; }

        public int Points { get; set; }

        public Coordinate Coordinate { get; set; }


    }
}
