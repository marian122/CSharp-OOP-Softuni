namespace LoggerLibrary.Appenders.Contracts
{
    using LoggerLibrary.Loggers.Enum;

    public interface IAppender
    {
        int MessagesCount { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}
