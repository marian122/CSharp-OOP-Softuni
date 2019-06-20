using StorageMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StorageMaster.Core.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            var vehicleType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Vehicle).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);

            if (vehicleType == null)
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }

            try
            {
                var storage = (Vehicle)Activator.CreateInstance(vehicleType);
                return storage;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }
    }
}
