﻿namespace _03BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using P03_BarraksWars.Core.CommandPattern;
    using System;
    using Microsoft.Extensions.DependencyInjection;

   public class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureService();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);

            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IUnitFactory, UnitFactory>();
            services.AddSingleton<IRepository, UnitRepository>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
