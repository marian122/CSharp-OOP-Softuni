﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public class Juice : Drink
    {
        private const decimal juicePrice = 1.80m;

        public Juice(string name, int servingSize, string brand)
            : base(name, servingSize, juicePrice, brand)
        {
        }
    }
}
