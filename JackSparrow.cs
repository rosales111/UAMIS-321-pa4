using UAMIS_321_pa4;
using System;

namespace UAMIS_321_pa4
{
    class JackSparrow : Character
    {
        public JackSparrow(string name) : base(name)
        {
            Random rand = new Random();
            MaxPower = rand.Next(1, 101);
            Health = 100;
            AttackStrength = rand.Next(1, MaxPower + 1);
            DefensivePower = rand.Next(1, MaxPower + 1);
        }

        public override int Attack(Character opponent)
        {
            // implement Jack Sparrow's distraction attack logic
            int attackPower = rand.Next(1, AttackStrength + 1);
            Console.WriteLine($"{Name} attacks with distraction for {attackPower} damage");
            opponent.TakeDamage(attackPower);
            return attackPower;
        }

        public override int Defend()
        {
            // implement Jack Sparrow's defense logic
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
