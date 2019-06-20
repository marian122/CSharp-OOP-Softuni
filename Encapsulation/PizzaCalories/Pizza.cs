﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name,Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15 || value.Length < 1)
                {
                    throw new InvalidOperationException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough
        {
            set
            {
                this.dough = value;
            }
        }
        
        public int NumberOfToppings => this.toppings.Count;

        public double TotalCalories => GetTotalCalories();

        public void AddTopping(Topping topping)
        {
            if (this.NumberOfToppings >= 10)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        private double GetTotalCalories()
        {
            var doughCalories = this.dough.Calories;
            var toppingCalories = this.toppings.Select(x => x.Calories).Sum();
            var totalCalories = doughCalories + toppingCalories;

            return totalCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }
    }
}
