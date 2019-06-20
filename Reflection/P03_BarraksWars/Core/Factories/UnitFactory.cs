namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = typeof(AppEntryPoint).Assembly;

            var currentUnitType = assembly
                .GetTypes()
                .FirstOrDefault(n => n.Name == unitType);

            return (IUnit)Activator.CreateInstance(currentUnitType);
                
        }
    }
}
