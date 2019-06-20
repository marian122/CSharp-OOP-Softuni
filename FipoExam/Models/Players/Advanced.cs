using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player
    {
        public Advanced(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, 250)
        {
        }

        public override void TakeDamage(int damagePoints)
        {
            if (this.Health < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");

            }
        }
    }
}
