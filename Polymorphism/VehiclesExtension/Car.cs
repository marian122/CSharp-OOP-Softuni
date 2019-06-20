using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionInLiterPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionInLiterPerKm, tankCapacity)
        {
            this.FuelConsumptionInLiterPerKm += 0.9; 
        }
        
    }
}
