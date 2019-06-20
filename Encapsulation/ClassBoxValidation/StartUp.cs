using ClassBox;
using System;

namespace ClassBoxValidation
{
    public class StartUp 
    {
        static void Main(string[] args)
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var heigth = double.Parse(Console.ReadLine());


            Box box;

            try
            {
                box = new Box(length, width, heigth);
            }
            catch (InvalidOperationException ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine(box.SurfaceArea());
            Console.WriteLine(box.LateralSurfaceArea());
            Console.WriteLine(box.VolumeArea());
        }
    }
}
