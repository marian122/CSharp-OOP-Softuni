using DungeonsAndCodeWizards.Cahracter;
using DungeonsAndCodeWizards.Cahracters.Enums;
using System;
using System.Linq;
using System.Reflection;

namespace DungeonsAndCodeWizards.Cahracters.Factory
{

    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string type, string name)
        {
            if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            var characterType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            if (characterType == null)
            {
                throw new ArgumentException($"Invalid character type \"{type}\"!");
            }

            var character = (Character)Activator.CreateInstance(characterType, name, parsedFaction);
            return character;

        }
    }
}
