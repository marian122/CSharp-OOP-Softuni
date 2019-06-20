using _03BarracksFactory.Contracts;
using P03_BarraksWars.CommandPattern;
using P03_BarraksWars.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Core.CommandPattern
{
    public class RetireCommand : Command
    {
        [InjectionAttribute]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository) 
            : base(data)
        {
            this.Repository = repository;
        }

        public IRepository Repository { get => repository; set => repository = value; }

        public override string Execute()
        {
            string unitType = this.Data[1];

            try
            {
                this.Repository.RemoveUnit(unitType);
                return $"{unitType} retired!";
            }
            catch (ArgumentException exception)
            {
                return exception.Message;
            }


        }
    }
}
