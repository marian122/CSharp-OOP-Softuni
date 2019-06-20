namespace LoggerLibrary.LoggerClass.Contracts
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string message);
    }
}
