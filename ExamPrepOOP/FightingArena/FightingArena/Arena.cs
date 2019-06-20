using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> arena;

        public Arena(string name)
        {
            this.Name = name;
            this.arena = new List<Gladiator>();
        }

        public string Name { get; set; }


        public void Add(Gladiator gladiator)
        {
            this.arena.Add(gladiator);
        }

        public void Remove(string name)
        {
            foreach (var item in arena)
            {
                if (item.Name == name)
                {
                    arena.Remove(item);
                    break;
                }
            }

        }

        public Gladiator GetGladitorWithHighestStatPower()
        {

            int statPower = 0;

            foreach (var stat in arena)
            {
                statPower = stat.GetStatPower();
            }
            return arena.FirstOrDefault(x=> x.GetStatPower() == statPower);
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            int weaponPower = 0;

            foreach (var stat in arena)
            {
                weaponPower = stat.GetWeaponPower();
            }
            return arena.FirstOrDefault(x => x.GetWeaponPower() == weaponPower);
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            int totalPower = 0;

            foreach (var stat in arena)
            {
                totalPower = stat.GetTotalPower();
            }
            return arena.FirstOrDefault(x => x.GetTotalPower() == totalPower);
        }

        public int Count => this.arena.Count;

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";
        }
    }
}
