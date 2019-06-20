﻿using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CosmosX.Entities.Reactors.ReactorFactory
{
    public class ReactorFactory : IReactorFactory
    {
        public IReactor CreateReactor(string reactorTypeName, int id, IContainer moduleContainer, int additionalParameter)
        {
            Type reactorType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == reactorTypeName);

            return (IReactor)Activator.CreateInstance(reactorType, id, moduleContainer);
        }
    }
}
