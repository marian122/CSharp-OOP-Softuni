using System;
using System.Collections.Generic;
using System.Linq;

namespace first
{
    class Program
    {
        static void Main(string[] args)
        {
            var wavesInput = int.Parse(Console.ReadLine());
            //var warriors = 0;
            //var platesInput = Console.ReadLine().Split().Select(int.Parse);
            //var plates = new Stack<int>(platesInput.Reverse());
            var warriors = new List<int>();
            var platesInput = Console.ReadLine().Split().Select(int.Parse);
            var plates = new List<int>(platesInput);

            for (int i = 0; i < wavesInput; i++)
            {
                var warr = Console.ReadLine().Split().Select(int.Parse);

                if (plates.Any() == false)
                {
                    break;
                }

                foreach (var item in warr)
                {
                    warriors.Add(item);
                }

                if (i == 2)
                {
                    var plateToAdd = int.Parse(Console.ReadLine());
                    plates.Add(plateToAdd);
                }

                while (warriors.Any() && plates.Any())
                {

                    if (warriors.Last() > plates.First())
                    {
                        var minusDmg = warriors.Last() - plates.First();
                        plates.Remove(plates.First());
                        warriors.Remove(warriors.Last());

                        warriors.Add(minusDmg);
                        
                    }
                    else if (plates.First() > warriors.Last())
                    {   
                        var minDmg = warriors.Last() - plates.First();
                        plates.Remove(plates.First());
                        plates.Add(Math.Abs(minDmg));
                        plates.Reverse();
                        warriors.Remove(warriors.Last());
                        
                    }

                    else 
                    {
                        warriors.Remove(warriors.Last());
                        plates.Remove(plates.First());
                        
                    }
                }


            }

            if (plates.Any())
            {
                Console.WriteLine($"The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                warriors.Reverse();
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", warriors)}");
            }          

        }
       
    }
}
//•If the warrior’s value is greater, he destroys the plate and lowers his value by the plate’s value, then attacks thenextplate,untilhisvaluereaches0.
//•If the plate’s value is greater, the warrior dies and the plate decreases its value by the warrior’s value.
//•If their values are equal, the warrior dies and the plate is destroyed.
