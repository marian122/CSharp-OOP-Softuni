using System;

namespace RetakeAdvancedExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());
            char[,] matrix = new char[lines, lines];

            int[] helenPos = new int[2];
            int[] parisPos = new int[2];
            int[] spartanPos = new int[2];

            var startingPos = 0;
            var startt = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] size = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    matrix[row, col] = size[col];

                    if (matrix[row, col] == 'H')
                    {
                        helenPos[0] = row;
                        helenPos[1] = col;
                    }

                    else if (matrix[row, col] == 'P')
                    {
                        parisPos[0] = row;
                        parisPos[1] = col;

                        startingPos = parisPos[0];
                        startt = parisPos[1];
                    }

                    else if (matrix[row, col] == 'S')
                    {
                        spartanPos[0] = row;
                        spartanPos[1] = col;
                    }
                }
            }

            var command = Console.ReadLine().Split();
            while (true)
            {

                var moveCommand = command[0];

                var firstEnemy = int.Parse(command[1]);
                var secondEnemy = int.Parse(command[2]);



                if (moveCommand == "up")
                {
                    energy -= 1;
                    parisPos = CommandUp(parisPos, matrix);



                    matrix[firstEnemy, secondEnemy] = 'S';
                    if (matrix[parisPos[0], parisPos[1]] == 'S')
                    {
                        energy -= 2;

                        if (energy <= 0)
                        {
                            matrix[startingPos, startt] = '-';
                            matrix[parisPos[0], parisPos[1]] = 'X';
                            Console.WriteLine($"Paris died at {parisPos[0]};{parisPos[1]}.");
                            break;
                        }

                    }


                    if (matrix[parisPos[0], parisPos[1]] == 'H')
                    {
                        if (energy >= 0)
                        {
                            Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");

                            matrix[parisPos[0], parisPos[1]] = '-';
                            matrix[startingPos, startt] = '-';

                        }
                        break;
                    }


                }

                else if (moveCommand == "down")
                {
                    energy -= 1;
                    parisPos = CommandDown(parisPos, matrix);

                    matrix[firstEnemy, secondEnemy] = 'S';
                    if (matrix[parisPos[0], parisPos[1]] == 'S')
                    {
                        energy -= 2;

                        if (energy <= 0)
                        {
                            matrix[startingPos, startt] = '-';
                            matrix[parisPos[0], parisPos[1]] = 'X';
                            Console.WriteLine($"Paris died at {parisPos[0]};{parisPos[1]}.");
                            break;
                        }

                    }


                    if (matrix[parisPos[0], parisPos[1]] == 'H')
                    {
                        if (energy >= 0)
                        {
                            Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");

                            matrix[parisPos[0], parisPos[1]] = '-';
                            matrix[startingPos, startt] = '-';

                        }
                        break;
                    }


                }

                else if (moveCommand == "left")
                {
                    energy -= 1;
                    parisPos = CommandLeft(parisPos, matrix);

                    matrix[firstEnemy, secondEnemy] = 'S';
                    if (matrix[parisPos[0], parisPos[1]] == 'S')
                    {
                        energy -= 2;

                        if (energy <= 0)
                        {
                            matrix[startingPos, startt] = '-';
                            matrix[parisPos[0], parisPos[1]] = 'X';
                            Console.WriteLine($"Paris died at {parisPos[0]};{parisPos[1]}.");
                            break;
                        }

                    }

                    if (matrix[parisPos[0], parisPos[1]] == 'H')
                    {
                        if (energy >= 0)
                        {
                            Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");

                            matrix[parisPos[0], parisPos[1]] = '-';
                            matrix[startingPos, startt] = '-';

                        }
                        break;
                    }


                }

                if (moveCommand == "right")
                {
                    energy -= 1;
                    parisPos = CommandRight(parisPos, matrix);

                    matrix[firstEnemy, secondEnemy] = 'S';
                    if (matrix[parisPos[0], parisPos[1]] == 'S')
                    {
                        energy -= 2;

                        if (energy <= 0)
                        {
                            matrix[startingPos, startt] = '-';
                            matrix[parisPos[0], parisPos[1]] = 'X';
                            Console.WriteLine($"Paris died at {parisPos[0]};{parisPos[1]}.");
                            break;
                        }

                    }


                    if (matrix[parisPos[0], parisPos[1]] == 'H')
                    {
                        if (energy >= 0)
                        {
                            Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");

                            matrix[parisPos[0], parisPos[1]] = '-';
                            matrix[startingPos, startt] = '-';

                        }
                        break;
                    }


                }
                command = Console.ReadLine().Split();

            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
        public static int[] CommandUp(int[] playerPosition, char[,] matrix)
        {
            if (playerPosition[0] - 1 >= 0)
            {
                playerPosition[0]--;
            }
            else
            {
                playerPosition[0] = matrix.GetLength(0) - 1;

            }
            return playerPosition;
        }
        public static int[] CommandDown(int[] playerPosition, char[,] matrix)
        {
            if (playerPosition[0] + 1 < matrix.GetLength(0))
            {
                playerPosition[0]++;
            }
            else
            {
                playerPosition[0] = matrix.GetLength(0);
            }
            return playerPosition;
        }
        public static int[] CommandLeft(int[] playerPosition, char[,] matrix)
        {
            if (playerPosition[1] - 1 >= 0)
            {
                playerPosition[1]--;
            }
            else
            {
                playerPosition[1] = matrix.GetLength(1) - 1;
            }
            return playerPosition;
        }
        public static int[] CommandRight(int[] playerPosition, char[,] matrix)
        {
            if (playerPosition[1] + 1 < matrix.GetLength(1))
            {
                playerPosition[1]++;
            }
            else
            {
                playerPosition[1] = 0;
            }
            return playerPosition;
        }
    }
}
