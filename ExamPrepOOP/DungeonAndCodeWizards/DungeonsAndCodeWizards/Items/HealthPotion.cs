using DungeonsAndCodeWizards.Cahracter;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities
{
    public class HealthPotion : Item
    {
        private const int healthWeigth = 5;
        private const int Healing = 20;
        
        public HealthPotion() 
            : base(healthWeigth)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health = Math.Min(0, character.Health + Healing);

            if (character.Health == 0)
            {
                character.IsAlive = false;
            }
        }

    }
}
