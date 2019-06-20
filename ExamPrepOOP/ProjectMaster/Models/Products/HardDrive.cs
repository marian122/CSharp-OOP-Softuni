using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Products
{
    public class HardDrive : Product
    {
        private const double hardDriveWeight = 0.7;

        public HardDrive(double price)
            : base(price, hardDriveWeight)
        {
        }
    }
}
