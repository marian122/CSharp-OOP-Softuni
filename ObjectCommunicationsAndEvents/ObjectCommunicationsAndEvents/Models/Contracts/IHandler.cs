using ObjectCommunicationsAndEvents.Models.Enums;

namespace ObjectCommunicationsAndEvents.Models.Contracts
{
    public interface IHandler
    {
        void Handle(LogType type, string message);

        void SetSuccessor(IHandler successor);
    }
}
