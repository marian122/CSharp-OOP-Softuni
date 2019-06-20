using DungeonsAndCodeWizards.Cahracter;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Cahracters.Contracts
{
    public interface IHealable
    {
        void Heal(Character character);
    }
}
