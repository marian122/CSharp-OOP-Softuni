using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Storages
{
    public class DistributionCenter : Storage
    {
        private static readonly Vehicle[] DefaultVehicles =
        {
            new Van(), new Van(), new Van()
        };

        public DistributionCenter(string name)
            : base(name, capacity: 2, garageSlots: 5, vehicles: DefaultVehicles)
        {
        }
    }

}
