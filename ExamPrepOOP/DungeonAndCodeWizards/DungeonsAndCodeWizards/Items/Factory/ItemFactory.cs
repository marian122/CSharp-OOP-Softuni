using DungeonsAndCodeWizards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards.Items.Factory
{
    public class ItemFactory
    {
        public Item CreateItem(string name)
        {
            var itemsType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(i => i.Name == name);

            if (itemsType == null)
            {
                throw new ArgumentException($"Invalid item \"{name}\"!");
            }

            var item = (Item)Activator.CreateInstance(itemsType);

            return item;
        }
    }
}
