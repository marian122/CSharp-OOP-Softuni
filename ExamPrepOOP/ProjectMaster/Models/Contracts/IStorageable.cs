using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Contracts
{
    public interface IStorageable
    {
        string Name { get; }
        int Capacity { get; }
        int GarageSlots { get; }
        bool IsFull { get; }
        Vehicle GetVehicle(int garageSlot);
        int SendVehicleTo(int garageSlot, Storage deliveryLocation);
        int UnloadVehicle(int garageSlot);

    }
}
