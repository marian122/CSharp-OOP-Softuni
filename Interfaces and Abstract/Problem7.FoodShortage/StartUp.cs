using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem7.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new List<IBuyer>();
            var times = int.Parse(Console.ReadLine());

            for (int i = 0; i < times; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);

                if (input.Length == 4)
                {
                    var Id = input[2];
                    var birthdate = input[3];

                    IBuyer human = new Citizen(name, age, Id, birthdate);

                    list.Add(human);
                }

                else if (input.Length == 3)
                {
                    var group = input[2];

                    IBuyer rebel = new Rebel(name, age, group);

                    list.Add(rebel);
                }

            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    int allFood = list.Sum(p => p.Food);
                    Console.WriteLine(allFood);
                    break;
                }

                var person = list.FirstOrDefault(p => p.Name == input);

                if (person != null)
                {
                    person.BuyFood();
                }
            }
        }
    }
}
