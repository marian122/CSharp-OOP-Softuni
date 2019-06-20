using _03BarracksFactory.Contracts;
using P03_BarraksWars.CommandPattern;
using P03_BarraksWars.CustomAttribute;

namespace P03_BarraksWars.Core.CommandPattern
{
    public class AddCommand : Command
    {
        [InjectionAttribute]
        private IRepository repository;

        [InjectionAttribute]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data)
        {
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        public IRepository Repository { get => repository; set => repository = value; }
        public IUnitFactory UnitFactory { get => unitFactory; set => unitFactory = value; }

        public override string Execute()
        { 
            string unitType = Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
