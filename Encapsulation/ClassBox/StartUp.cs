using System;

namespace ClassBox
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var heigth = double.Parse(Console.ReadLine());


            Box box = new Box(length, width, heigth);

            Console.WriteLine(box.SurfaceArea());
            Console.WriteLine(box.LateralSurfaceArea());
            Console.WriteLine(box.VolumeArea());

        }
    }
}
