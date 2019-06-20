using DungeonsAndCodeWizards.Cahracter;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities
{
    public class ArmorRepairKit : Item
    {
        private const int armorWeigth = 10;

        public ArmorRepairKit() 
            : base(armorWeigth)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Armor = character.BaseArmor;
            
        }

    }
}
