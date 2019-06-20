using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_3._Ferrari
{
    public interface IDrive
    {
        string Model { get;}

        string Driver { get;}

        string Brakes();

        string GasPedal();
    }
}
