using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int baseCalories = 2;
        private string type;
        private double weigth;


        public Topping(string type, double weigth)
        {
            this.Type = type;
            this.Weigth = weigth;

        }

        public string Type
        {
            get => this.type;

            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new InvalidOperationException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }

        }

        public double Weigth
        {
            get => this.weigth;

            set
            {
                if (value < 1 || value > 50)
                {
                    throw new InvalidOperationException($"{value} weight should be in the range [1..50].");
                }
                this.weigth = value;
            }
        }

        public double Calories => GetCalories();

        private double GetCalories()
        {
            var modifier = 0.0;

            switch (this.Type.ToLower())
            {
                case "meat":
                    modifier = 1.2;
                    break;
                case "veggies":
                    modifier = 0.8;
                    break;
                case "cheese":
                    modifier = 1.1;
                    break;
                case "sauce":
                    modifier = 0.9;
                    break;
            }

            var calories = baseCalories * this.Weigth * modifier;
            return calories;

        }
    }
}
