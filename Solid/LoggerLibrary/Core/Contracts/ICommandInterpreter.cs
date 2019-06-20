namespace LoggerLibrary.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] input);

        void AddMessage(string[] input);

        void PrintInfo();
    }
}
