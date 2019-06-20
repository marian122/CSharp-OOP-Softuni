using System;
using System.Linq;

namespace OddEven
{
    class Program
    {
        static void Main(string[] args)
       {
            var homeTeamWonsCount = 0;
            var awayTeamWonsCount = 0;
            var drawGames = 0;

            for (int i = 0; i < 3; i++)
            {
                var input = Console.ReadLine().Split(':');

                var homeTeam = int.Parse(input[0]);
                var awayTeam = int.Parse(input[1]);
               
                if (homeTeam > awayTeam)
                {
                    homeTeamWonsCount++;
                }

                else if (homeTeam < awayTeam)
                {
                    awayTeamWonsCount++;
                }

                else
                {
                    drawGames++;
                }
            }
            Console.WriteLine($"Team won {homeTeamWonsCount} games.");
            Console.WriteLine($"Team lost {awayTeamWonsCount} games.");
            Console.WriteLine($"Drawn games: {drawGames}");
        }
    }
}