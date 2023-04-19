using UAMIS_321_pa4;
using System;
namespace UAMIS_321_pa4
{
    class DavyJones : Character
    {
        public DavyJones(string name) : base(name)
        {
            Random rand = new Random();
            MaxPower = rand.Next(1, 101);
            Health = 100;
            AttackStrength = rand.Next(1, MaxPower + 1);
            DefensivePower = rand.Next(1, MaxPower + 1);
        }
        public override int Attack(Character opponent)
        {
            // implement Davy Jones's cannon fire attack logic
            int attackPower = rand.Next(1, AttackStrength + 1);
            Console.WriteLine($"{Name} attacks with cannon fire for {attackPower} damage");
            opponent.TakeDamage(attackPower);
            return attackPower;
        }

        public override int Defend()
        {
            // implement Davy Jones's sword logic
            int defensePower = rand.Next(1, DefensivePower + 1);
            Console.WriteLine($"{Name} defends with parry for {defensePower} defense");
            return defensePower;
        }

        public override string GetStats()
        {
            return $"{Name}: MaxPower={MaxPower}, Health={Health}, AttackStrength={AttackStrength}, DefensivePower={DefensivePower}";
        }
    }
}