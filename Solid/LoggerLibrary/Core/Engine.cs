namespace LoggerLibrary.Core
{
    using LoggerLibrary.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            var line = int.Parse(Console.ReadLine());

            for (int i = 0; i < line; i++)
            {
                var input = Console.ReadLine().Split();

                this.commandInterpreter.AddAppender(input);
            }

            while (true)
            {
                var input = Console.ReadLine().Split('|');

                if (input[0] == "END")
                {
                    break;
                }

                this.commandInterpreter.AddMessage(input);
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
