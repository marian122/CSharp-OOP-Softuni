using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Contracts
{
    public interface IProductable
    {
        double Price { get; }
        double Weight { get; }

    }
}
