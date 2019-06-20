using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionInLiterPerKm) 
            : base(fuelQuantity, fuelConsumptionInLiterPerKm)
        {
            this.FuelConsumptionInLiterPerKm += 1.6;
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += (liters * 0.95);
        }
    }
}
