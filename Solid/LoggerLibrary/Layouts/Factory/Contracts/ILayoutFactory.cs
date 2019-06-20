namespace LoggerLibrary.Layouts.Factory.Contracts
{
    using LoggerLibrary.Contracts;

    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
