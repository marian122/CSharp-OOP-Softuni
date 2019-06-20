using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_3._Ferrari
{
    public class Ferrari : IDrive
    {
        public Ferrari(string driver)
        {
            this.Model = "488-Spider";
            this.Driver = driver;
        }

        public string Model { get; set; }

        public string Driver { get; set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string GasPedal()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{Brakes()}/{GasPedal()}/{this.Driver}";
        }
    }
}
