using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem6.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new List<IIDentify>();

            var input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                if (input[0] == "Citizen")
                {
                    var name = input[1];
                    var age = int.Parse(input[2]);
                    var Id = input[3];
                    var birthdate = input[4];

                    IIDentify human = new Citizen(name, age, Id, birthdate);

                    list.Add(human);
                }

                else if (input[0] == "Pet")
                {
                    var name = input[1];
                    var birthdate = input[2];

                    IIDentify pet = new Pet(name, birthdate);

                    list.Add(pet);
                }

                input = Console.ReadLine().Split();


            }

            var lastDigits = Console.ReadLine();

            list
                .Select(n => n.Birthdate)
                .Where(n => n.EndsWith(lastDigits))
                .ToList()
                .ForEach(Console.WriteLine);

        }
    }
}
