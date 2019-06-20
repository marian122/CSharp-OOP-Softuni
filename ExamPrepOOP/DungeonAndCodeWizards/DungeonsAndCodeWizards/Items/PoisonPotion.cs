using DungeonsAndCodeWizards.Cahracter;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities
{
    public class PoisonPotion : Item
    {
        private const int poisonWeigth = 5;
        private const int HitPoints = 20;

        public PoisonPotion() 
            : base(poisonWeigth)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health = Math.Min(0, character.Health - HitPoints);

            if (character.Health == 0)
            {
                character.IsAlive = false;
            }
        }

    }
}
