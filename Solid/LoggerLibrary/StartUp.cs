﻿namespace LoggerLibrary
{
    using LoggerLibrary.Core;
    using LoggerLibrary.Core.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();


        }
    }
}
