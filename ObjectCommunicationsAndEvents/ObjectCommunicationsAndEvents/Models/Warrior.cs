using System;
using ObjectCommunicationsAndEvents.Models;

public class Warrior : AbstractHero
{
    private const string ATTACK_MESSAGE = "{0} damages {1} for {2}";
    private Logger combatLog;

    public Warrior(string id, int damage) : base(id, damage)
    {
    }

    public Warrior(string id, int damage, Logger combatLog) 
        : this(id, damage)
    {
        this.combatLog = combatLog;
    }

    protected override void ExecuteClassSpecificAttack(ITarget target, int damage)
    {
        Console.WriteLine(ATTACK_MESSAGE, this, target, damage);
    }
}
