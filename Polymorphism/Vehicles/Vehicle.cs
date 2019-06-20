using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionInLiterPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionInLiterPerKm = fuelConsumptionInLiterPerKm;
        }

        public double FuelQuantity { get; protected set; }
        public double FuelConsumptionInLiterPerKm { get; protected set; }

        public string Drive(double distance)
        {
            if (this.FuelConsumptionInLiterPerKm * distance <= this.FuelQuantity)
            {
                this.FuelQuantity -= (this.FuelConsumptionInLiterPerKm * distance);
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public abstract void Refuel(double liters);

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

    }
}
