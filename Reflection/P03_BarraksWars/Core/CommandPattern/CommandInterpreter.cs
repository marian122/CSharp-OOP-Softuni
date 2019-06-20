using _03BarracksFactory.Contracts;
using P03_BarraksWars.CustomAttribute;
using System;
using System.Linq;
using System.Reflection;

namespace P03_BarraksWars.Core.CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {

        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type commandType = assembly.GetTypes().First(t => t.Name.ToLower() == commandName + "command");

            FieldInfo[] fieldsInjection = commandType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.CustomAttributes
                .Any(a => a.AttributeType == typeof(InjectionAttribute)))
                .ToArray();

            object[] fields = fieldsInjection
                .Select(x => this.serviceProvider
                .GetService(x.FieldType))
                .ToArray();

            object[] arguments = new object[] { data }.Concat(fields).ToArray();

            IExecutable command = (IExecutable)Activator
                .CreateInstance(commandType, arguments);

            return command;
        }
    }
}
