using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            return this.Stat.Agility + this.Stat.Flexibility + this.Stat.Intelligence + this.Stat.Skills + this.Stat.Strength + this.Weapon.Sharpness + this.Weapon.Size + this.Weapon.Solidity;
        }

        public int GetWeaponPower()
        {
            return this.Weapon.Sharpness + this.Weapon.Size + this.Weapon.Solidity;
        }

        public int GetStatPower()
        {
            return this.Stat.Agility + this.Stat.Flexibility + this.Stat.Intelligence + this.Stat.Skills + this.Stat.Strength;
        }

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.GetTotalPower()}]" + Environment.NewLine +
                    $"Weapon Power: [{this.GetWeaponPower()}]" + Environment.NewLine +
                    $"Stat Power: [{this.GetStatPower()}]";

        }
    }
}
