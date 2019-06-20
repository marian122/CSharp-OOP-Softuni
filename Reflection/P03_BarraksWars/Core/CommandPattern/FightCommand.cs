using _03BarracksFactory.Contracts;
using P03_BarraksWars.CommandPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Core.CommandPattern
{
    public class FightCommand : Command
    {
        public FightCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}
