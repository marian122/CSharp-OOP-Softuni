using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBox
{
    public class Box
    {
        private double length;
        private double heigth;
        private double width;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public double Height
        {
            get => this.heigth;
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException("Height cannot be zero or negative.");
                }

                this.heigth = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
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
