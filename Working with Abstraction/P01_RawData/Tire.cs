﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tire
    {
        private int age;

        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.age = age;
        }

        public double Pressure { get; private set; }
        public int Age { get; private set; }
    }
}
