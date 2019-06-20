using System;
using ObjectCommunicationsAndEvents.Models;

public class Dragon : ITarget
{
    private const string THIS_DIED_EVENT = "{0} dies";

    private string id;
    private int hp;
    private int reward;
    private bool eventTriggered;
    private Logger combatLog;

    public Dragon(string id, int hp, int reward)
    {
        this.id = id;
        this.hp = hp;
        this.reward = reward;
    }

    public Dragon(string id, int hp, int reward, Logger combatLog) 
        : this(id, hp, reward)
    {
        this.combatLog = combatLog;
    }

    public bool IsDead { get => this.hp <= 0; }

    public void ReceiveDamage(int damage)
    {
        if (!this.IsDead)
        {
            this.hp -= damage;
        }

        if(this.IsDead && !eventTriggered)
        {
            Console.WriteLine(THIS_DIED_EVENT, this);
            this.eventTriggered = true;
        }
    }

    public override string ToString()
    {
        return this.id;
    }
}
