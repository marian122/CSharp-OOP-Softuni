using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumptionInLiterPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionInLiterPerKm, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            if ((this.FuelConsumptionInLiterPerKm + 1.4) * distance <= this.FuelQuantity)
            {
                this.FuelQuantity -= ((this.FuelConsumptionInLiterPerKm + 1.4) * distance);
                return $"{this.GetType().Name} travelled {distance} km";
            }

            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public string DriveEmpty(double distance)
        {
            return base.Drive(distance);
        }
    }
}
