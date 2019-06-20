using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionInLiterPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionInLiterPerKm, tankCapacity)
        {
            this.FuelConsumptionInLiterPerKm += 1.6;
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            this.FuelQuantity -= (liters * 0.05);
        }
    }
}
