﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class Dessert : Food
    {
        private const int servingDessertSize = 200;

        public Dessert(string name, decimal price) 
            : base(name, servingDessertSize, price)
        {
        }
    }
}
