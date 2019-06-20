using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Car
    {
        public Tesla(string model, string color, int batteries)
            :base(model, color)
        {
            this.Battery = batteries;
        }

        public int Battery { get; private set; }

        public override string GetInfo()
        {
            return $"{base.GetInfo()} with {this.Battery} Batteries";
        }
    }
}
