﻿using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            Team team = new Team("My team");
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split();
                var firstName = input[0];
                var lastName = input[1];
                var age = int.Parse(input[2]);
                var salary = decimal.Parse(input[3]);

                try
                {
                    var player = new Person(firstName
                        , lastName
                        , age
                        , salary);

                    team.AddPlayer(player);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
