namespace LoggerLibrary.LoggerClass
{
    using LoggerLibrary.Appenders.Contracts;
    using LoggerLibrary.LoggerClass.Contracts;
    using LoggerLibrary.Loggers.Enum;

    public class Logger : ILogger
    {
        private IAppender consoleAppender;
        private IAppender fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAppender)
            :this (consoleAppender)
        {
            this.consoleAppender = consoleAppender;
            this.fileAppender = fileAppender;
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            this.Append(dateTime, ReportLevel.FATAL, fatalMessage);
        }

        public void Warning(string dateTime, string warningMessage)
        {
            this.Append(dateTime, ReportLevel.WARNING, warningMessage);
        }

        public void Critical(string dateTime, string criticalMessage)
        {
            this.Append(dateTime, ReportLevel.CRITICAL, criticalMessage);
        }

        public void Error(string dateTime, string errorMessage)
        {
            this.Append(dateTime,ReportLevel.ERROR, errorMessage);
        }

        public void Info(string dateTime, string infoMessage)
        {
            this.Append(dateTime, ReportLevel.INFO, infoMessage);
        }

        private void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            consoleAppender?.Append(dateTime, reportLevel, message);
            fileAppender?.Append(dateTime, reportLevel, message);
        }
    }
}
