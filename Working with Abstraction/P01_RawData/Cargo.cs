﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Cargo
    {
        private int cargoWeight;

        public Cargo(int cargoWeight, string cargoType)
        {
            this.cargoWeight = cargoWeight;
            this.CargoType = cargoType;
        }

        public string CargoType { get; private set; }
    }
}
