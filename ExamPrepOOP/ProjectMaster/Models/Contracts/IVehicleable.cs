using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Contracts
{
    public interface IVehicleable
    {
        int Capacity { get; }
        bool IsFull { get; }
        bool IsEmpty { get; }
        void LoadProduct(Product product);
        Product Unload();

    }
}
