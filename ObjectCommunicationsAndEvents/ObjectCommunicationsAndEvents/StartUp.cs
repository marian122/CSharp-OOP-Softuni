using ObjectCommunicationsAndEvents.CommandPatterns;
using ObjectCommunicationsAndEvents.CommandPatterns.Contracts;
using ObjectCommunicationsAndEvents.Models;
using ObjectCommunicationsAndEvents.Models.Loggers;
using System;

namespace Object_Communication_and_Events_Lab
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Logger combatLog = new CombatLogger();
            Logger eventLog = new EventLogger();

            combatLog.SetSuccessor(eventLog);

            var warrior = new Warrior("gosho", 10, combatLog);
            var dragon = new Dragon("ivan", 100, 25, combatLog);

            IExecutor executor = new CommandExecutor();
            ICommand command = new TargetCommand(warrior, dragon);
            ICommand attack = new AttackCommand(warrior);

        }
    }
} 
