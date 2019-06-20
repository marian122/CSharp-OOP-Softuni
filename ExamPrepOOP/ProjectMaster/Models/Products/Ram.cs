﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Products
{
    public class Ram : Product
    {
        private const double ramWeight = 0.7;

        public Ram(double price) 
            : base(price, ramWeight)
        {
        }
    }
}
