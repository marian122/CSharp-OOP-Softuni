using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionInLiterPerKm) 
            : base(fuelQuantity, fuelConsumptionInLiterPerKm)
        {
            this.FuelConsumptionInLiterPerKm += 0.9; 
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
