using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Storages
{
    public class Warehouse : Storage
    {
        private static readonly Vehicle[] DefaultVehicles =
         {
            new Semi(), new Semi(), new Semi()
        };

        public Warehouse(string name)
            : base(name, capacity: 10, garageSlots: 10, vehicles: DefaultVehicles)
        {
        }
    }
}
