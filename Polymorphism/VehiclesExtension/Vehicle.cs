using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionInLiterPerKm, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;
            }

            else
            {
                this.FuelQuantity = fuelQuantity;
            }

            this.FuelConsumptionInLiterPerKm = fuelConsumptionInLiterPerKm;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; protected set; }
        public double FuelConsumptionInLiterPerKm { get; protected set; }
        public double TankCapacity { get; protected set; }

        public virtual string Drive(double distance)
        {
            var vehicleName = this.GetType().Name;
            if (this.FuelConsumptionInLiterPerKm * distance <= this.FuelQuantity)
            {
                this.FuelQuantity -= (this.FuelConsumptionInLiterPerKm * distance);
                return $"{vehicleName} travelled {distance} km";
            }

            return $"{vehicleName} needs refueling";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }


        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

    }
}
