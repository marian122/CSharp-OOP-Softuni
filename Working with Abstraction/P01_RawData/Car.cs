﻿namespace RawData
{
    using System.Collections.Generic;

    public class Car
    {
        private const int tireCount = 4;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }
        
        public string Model { get; private set; }
        public Engine Engine { get; private set; }
        public Cargo Cargo { get ; private set; }
        public Tire[] Tires { get; private set; }
    }
}
