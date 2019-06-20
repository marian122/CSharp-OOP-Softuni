using System;
using System.Collections.Generic;
using System.Text;
using ObjectCommunicationsAndEvents.Models.Enums;

namespace ObjectCommunicationsAndEvents.Models.Loggers
{
    public class EventLogger : Logger
    {
        public override void Handle(LogType type, string message)
        {
            switch (type)
            {
                case LogType.ATTACK:
                    break;
                case LogType.MAGIC:
                    break;
                case LogType.TARGET:
                    break;
                case LogType.ERROR:
                    break;
                case LogType.EVENT:
                    break;
                default:
                    break;
            }
        }
    }
}
