using DungeonsAndCodeWizards.Cahracter;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Cahracters.Contracts
{
    public interface IAttackable
    {
        void Attack(Character character);
    }
}
