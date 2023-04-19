using System;

namespace UAMIS_321_pa4
{
    class Battle
    {
        private Character player1;
        private Character player2;


        public Battle(Character player1, Character player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public void Start()
        {
            System.Console.WriteLine($"Starting battle between {player1.Name} and {player2.Name}");

            if (!player1.IsAlive() || !player2.IsAlive())
            {
                System.Console.WriteLine("The battle cannot start!");
            }


            while (player1.IsAlive() && player2.IsAlive())
            {
                //player 1 attacks
                int damage = player1.Attack(player2) - player2.Defend();
                if(damage > 0)
                {
                    player2.TakeDamage(damage);
                    System.Console.WriteLine($"{player2.Name} takes {damage} damage.");
                }
                else
                {
                    System.Console.WriteLine($"{player2.Name} blocks the attack.");
                }

                //check if player 2 is still alive
                if(!player2.IsAlive())
                {
                    System.Console.WriteLine($"{player1.Name} Wins!");
                    break;
                }

                //Player 2 attacks 
                damage = player2.Attack(player1) - player1.Defend();
                if (damage > 0)
                {
                    player1.TakeDamage(damage);
                    System.Console.WriteLine($"{player1.Name} takes {damage} damage.");
                }
                else
                {
                    System.Console.WriteLine($"{player1.Name} blocks the attack.");
                }

                //check if player 1 is still alive
                if(!player1.IsAlive())
                {
                    System.Console.WriteLine($"{player2.Name} Wins!");
                    break;
                }
            }
            System.Console.WriteLine($"Battle between {player1.Name} and {player2.Name} is over.");

        }

    }


}