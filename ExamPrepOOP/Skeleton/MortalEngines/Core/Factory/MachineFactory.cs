using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;
using System;

namespace MortalEngines.Core.Factory
{
    public class MachineFactory
    {
        public BaseMachine CreateMachine(string name, double attackPoints, double defensePoints)
        {
            switch (name)
            {
                case "Fighter":
                    return new Fighter(name, attackPoints, defensePoints);

                case "Tank":
                    return new Tank(name, attackPoints, defensePoints);

                default:
                    throw new ArgumentException("Invalid type!");
                    
            }
        }
    }
}
