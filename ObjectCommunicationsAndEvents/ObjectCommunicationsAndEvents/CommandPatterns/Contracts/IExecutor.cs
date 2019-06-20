using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectCommunicationsAndEvents.CommandPatterns.Contracts
{
    public interface IExecutor
    {
        void ExecuteCommand(ICommand command);
    }
}
