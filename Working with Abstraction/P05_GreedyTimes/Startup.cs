using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyTimes
{

    public class Startup
    {
        static void Main(string[] args)
        {
            var bagCapacity = long.Parse(Console.ReadLine());
            var quantity = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long minerals = 0;
            decimal money = 0;

            InputCheck(bagCapacity, quantity, bag,  gold, minerals,  money);

            Print(bag);
        }

        private static void InputCheck(long bagCapacity, string[] quantity, Dictionary<string, Dictionary<string, long>> bag, long gold, long minerals,  decimal money)
        {
            for (int i = 0; i < quantity.Length; i += 2)
            {
                string name = quantity[i];
                long count = long.Parse(quantity[i + 1]);

                string firstInput = string.Empty;

                if (name.Length == 3)
                {
                    firstInput = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    firstInput = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    firstInput = "Gold";
                }

                if (firstInput == "")
                {
                    continue;
                }
                else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + count)
                {
                    continue;
                }

                switch (firstInput)
                {
                    case "Gem":
                        if (!bag.ContainsKey(firstInput))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (count > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[firstInput].Values.Sum() + count > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(firstInput))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (count > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[firstInput].Values.Sum() + count > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                DictionaryFilling(bag, gold, minerals, money, name, count, firstInput);
            }
        }

        private static void DictionaryFilling(Dictionary<string, Dictionary<string, long>> bag, long gold, long minerals, decimal money, string name, long count, string firstInput)
        {
            if (!bag.ContainsKey(firstInput))
            {
                bag[firstInput] = new Dictionary<string, long>();
            }

            if (!bag[firstInput].ContainsKey(name))
            {
                bag[firstInput][name] = 0;
            }

            bag[firstInput][name] += count;
            if (firstInput == "Gold")
            {
                gold += count;
            }
            else if (firstInput == "Gem")
            {
                minerals += count;
            }
            else if (firstInput == "Cash")
            {
                money += count;
            }
        }

        private static void Print(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}