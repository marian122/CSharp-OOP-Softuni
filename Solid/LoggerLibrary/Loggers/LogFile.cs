namespace LoggerLibrary.Loggers
{
    using LoggerLibrary.LoggerClass.Contracts;
    using System.Linq;

    public class LogFile : ILogFile
    {
       
        public int Size { get; private set; }

        public void Write(string message)
        {
            this.Size += message.Where(char.IsLetter).Sum(s => s);
        }
    }
}
