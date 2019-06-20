using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
   public class Engine
    {
        private int engineSpeed;

        public Engine(int engineSpeed, int enginePower)
        {
            this.engineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }

        public int EnginePower { get; private set; }
    }
}
