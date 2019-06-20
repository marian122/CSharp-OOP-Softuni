using ObjectCommunicationsAndEvents.CommandPatterns.Contracts;
using System;

namespace ObjectCommunicationsAndEvents.CommandPatterns
{
    public class TargetCommand : ICommand
    {
        private Warrior warrior;
        private Dragon dragon;

        public TargetCommand(Warrior warrior, Dragon dragon)
        {
            this.warrior = warrior;
            this.dragon = dragon;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
