using UAMIS_321_pa4;
using System;

namespace UAMIS_321_pa4
{
public abstract class Character
{
    public string Name {get; set;}
    private int maxPower;
    public int MaxPower 
    {
        get {return maxPower;}
        set
        {
            maxPower = value;
            if(AttackStrength > maxPower)
            {
                AttackStrength = maxPower;
            }
            if(DefensivePower > maxPower)
            {
                DefensivePower = maxPower;
            }
        }
    }
    private int health {get; set;} = 100;
    public int Health
    {
        get{return health;}
        protected set {health = Math.Min(value, MaxHealth);}
    }
    public int MaxHealth{get; set;} = 100;
    public int AttackStrength {get; set;}
    public int DefensivePower {get; set;}
    protected Random rand = new Random();

    public Character(string name)
    {
        Name = name;
    }


    public virtual int Attack(Character opponent)
    {
        //Calacualte attack power and inflict damage on the opponent 
        int attackPower = rand.Next(1, AttackStrength + 1);
        opponent.TakeDamage(attackPower);
        System.Console.WriteLine($"{Name} attacks {opponent.Name} for {attackPower} damage.");

        //Return the attack power
        return attackPower;
    }
    public virtual int Defend()
    {
        return 0;
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if(!IsAlive())
        {
            System.Console.WriteLine($"{Name} has been defeated!");
        }
    }
    public virtual string GetStats()
    {
        return "";
    }
    public bool IsAlive()
    {
        return Health > 0;
    }


}

}