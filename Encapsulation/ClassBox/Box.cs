using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double heigth;

        
        public Box(double length, double width, double heigth)
        {
            this.length = length;
            this.width = width;
            this.heigth = heigth;
        }

        

        public string VolumeArea()
        {
            var volume = this.length * this.width * this.heigth;

            return $"Volume - {volume:F2}";
        }

        public string LateralSurfaceArea()
        {
            var lateralSurfaceArea = (2 * (length * heigth)) + (2 * (width * heigth));

            return $"Lateral Surface Area - {lateralSurfaceArea:F2}";
        }

        public string SurfaceArea()
        {
            var surfaceArea = (2 * (length * width)) + (2 * (length * heigth)) + (2 * (width * heigth));

            return $"Surface Area - {surfaceArea:f2}";
        }
    }
}
