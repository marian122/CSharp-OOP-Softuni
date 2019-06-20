namespace LoggerLibrary.Appenders.Factory.Contracts
{
    using LoggerLibrary.Appenders.Contracts;
    using LoggerLibrary.Contracts;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);


    }
}
