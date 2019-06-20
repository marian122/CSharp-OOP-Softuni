using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem5.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new List<IIDentify>();

            var input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                if (input.Length == 3)
                {
                    var name = input[0];
                    var age = int.Parse(input[1]);
                    var Id = input[2];

                    IIDentify human = new Citizen(name, age, Id);

                    list.Add(human);
                }

                else
                {
                    var model = input[0];
                    var Id = input[1];

                    IIDentify robot = new Robot(model, Id);

                    list.Add(robot);
                }
                input = Console.ReadLine().Split();


            }
            var lastDigits = Console.ReadLine();

            list.Where(n => n.Id.EndsWith(lastDigits))
                .Select(n => n.Id)
                .ToList()
                .ForEach(Console.WriteLine);

        }
    }
}
