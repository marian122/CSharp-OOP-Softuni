using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class Salad : Food
    {
        private const int servingSaladSize = 300;

        public Salad(string name, decimal price) 
            : base(name, servingSaladSize, price)
        {
        }
    }
}
