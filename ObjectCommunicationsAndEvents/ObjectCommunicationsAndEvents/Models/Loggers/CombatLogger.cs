using ObjectCommunicationsAndEvents.Models.Enums;

namespace ObjectCommunicationsAndEvents.Models.Loggers
{
    public class CombatLogger : Logger
    {
        public override void Handle(LogType type, string message)
        {
            switch (type)
            {
                case LogType.ATTACK:
                    break;
                case LogType.MAGIC:
                    break;
                
            }
            this.PassToSuccessor(type, message);
        }
    }
}
