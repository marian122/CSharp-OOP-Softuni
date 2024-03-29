﻿using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;
        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
        }


        public int TableNumber { get; private set; }
        public int Capacity
        {
            get => this.capacity;

            set
            {
                if (value <= 0 )
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }
        public bool IsReserved { get; private set; }
        public decimal Price => this.numberOfPeople * this.PricePerPerson;

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return this.drinkOrders.Sum(x => x.Price) + this.foodOrders.Sum(x => x.Price) + this.Price;
        }

        public string GetFreeTableInfo()
        {
            return $"Table: {this.TableNumber}" + Environment.NewLine +
                   $"Type: {this.GetType().Name}" + Environment.NewLine +
                   $"Capacity: {this.Capacity}" + Environment.NewLine +
                   $"Price per Person: {this.PricePerPerson}";

        }

        public string GetOccupiedTableInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.numberOfPeople}");

            if (this.foodOrders.Count <= 0)
            {
                sb.AppendLine("Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {this.foodOrders.Count}");
                sb.AppendLine(string.Join(Environment.NewLine, this.foodOrders));
            }


            if (this.drinkOrders.Count <= 0)
            {
                sb.AppendLine($"Drink orders: None");
            }

            else
            {
                sb.AppendLine($"Drink orders: {this.drinkOrders.Count}");
                sb.AppendLine(string.Join(Environment.NewLine, this.drinkOrders));

            }

            return sb.ToString().Trim();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
