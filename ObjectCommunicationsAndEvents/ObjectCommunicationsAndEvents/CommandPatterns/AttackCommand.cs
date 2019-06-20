using ObjectCommunicationsAndEvents.CommandPatterns.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectCommunicationsAndEvents.CommandPatterns
{
    public class AttackCommand : ICommand
    {
        private Warrior warrior;

        public AttackCommand(Warrior warrior)
        {
            this.warrior = warrior;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
