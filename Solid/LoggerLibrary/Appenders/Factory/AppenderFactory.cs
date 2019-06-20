using LoggerLibrary.Appenders.Contracts;
using LoggerLibrary.Appenders.Factory.Contracts;
namespace LoggerLibrary.Appenders.Factory
{
    using LoggerLibrary.Contracts;
    using LoggerLibrary.Loggers;
    using System;

    public class AppenderFactory : IAppenderFactory
    {

        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeToLower = type.ToLower();

            switch (typeToLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);

                case "fileappender":
                    return new FileAppender(layout, new LogFile());

                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
