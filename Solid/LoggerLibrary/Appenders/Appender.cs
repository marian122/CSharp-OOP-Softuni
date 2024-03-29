﻿using LoggerLibrary.Appenders.Contracts;
namespace LoggerLibrary.Appenders
{
    using LoggerLibrary.Contracts;
    using LoggerLibrary.Loggers.Enum;

    public abstract class Appender : IAppender
    {
        private readonly ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        protected ILayout Layout => this.layout;

        public ReportLevel ReportLevel { get; set; }

        public int MessagesCount { get; protected set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}
