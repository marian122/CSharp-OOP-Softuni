using System;

namespace Shapes
{
    public class StartUp 
    {
        static void Main(string[] args)
        {
            try
            {
                var radius = int.Parse(Console.ReadLine());
                IDrawable circle = new Circle(radius);

                var width = int.Parse(Console.ReadLine());
                var height = int.Parse(Console.ReadLine());
                IDrawable rect = new Rectangle(width, height);

                circle.Draw();
                rect.Draw();
            }

            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
