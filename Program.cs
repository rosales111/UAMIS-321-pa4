using System;

namespace UAMIS_321_pa4
{
    class Program
    {
        static void Main(string[] args)
        {
            //prompt for player names
            System.Console.WriteLine("Enter Player 1 name: ");
            string player1Name = Console.ReadLine();

            //Prompt for player 1 character selection
            System.Console.WriteLine("Select a character for Player 1:");
            System.Console.WriteLine("1. Jack Sparrow");
            System.Console.WriteLine("2. Will Turner");
            System.Console.WriteLine("3. Davy Jones");
            System.Console.WriteLine("Enter selection: ");
            int player1Selection = int.Parse(Console.ReadLine());

            //Create player 1 character
            Character player1Character;
            switch (player1Selection)
            {
                case 1:
                    player1Character = new JackSparrow("Jack Sparrow");
                    break;
                case 2:
                    player1Character = new WillTurner("Will Turner");
                    break;
                case 3:
                    player1Character = new DavyJones("Davy Jones");
                    break;
                default:
                    System.Console.WriteLine("Invalid selection. Please enter a number from 1 to 3.");
                    // Prompt the user again to make a valid selection
                    System.Console.Write("Player 1, select your character: ");
                    int.TryParse(System.Console.ReadLine(), out player1Selection);
                    player1Character = null;
                    break;
            }

            // Assign remaining character to player 2
            Character player2Character;
            if (player1Character is JackSparrow)
            {
                player2Character = new WillTurner("Player 2");
            }
            else if (player1Character is WillTurner)
            {
                player2Character = new DavyJones("Player 2");
            }
            else
            {
                player2Character = new JackSparrow("Player 2");
            }

            //Prompt for player 2 name
            System.Console.WriteLine("Enter Player 2 name: ");
            string player2Name = Console.ReadLine();

            //Start the game
            System.Console.WriteLine("Let the battle begin!");
            System.Console.WriteLine($"{player1Name} ({player1Character.GetType().Name}) vs. {player2Name} ({player2Character.GetType().Name})");
            Console.WriteLine();

            //Randomly determine which player attacks first
            Random rand = new Random();
            bool player1AttacksFirst = rand.Next(2) == 0;

            //Loop until one character's health reaches 0
            Character attacker = player1AttacksFirst ? player1Character : player2Character;
            Character defender = player1AttacksFirst ? player2Character : player1Character;
            while (attacker.Health > 0 && defender.Health > 0)
            {
                //Display attacker's stats
                System.Console.WriteLine($"{attacker.GetType().Name} ({attacker.Health} HP, {attacker.AttackStrength} AP, {attacker.DefensivePower} DP)");

                //Attack
                int damageDealt = attacker.Attack(defender);
                System.Console.WriteLine($"{attacker.Name} attacks {defender.Name} for {damageDealt} damage.");

                //Display defender's stats
                System.Console.WriteLine($"{defender.Name} ({defender.Health} HP, {defender.AttackStrength} AP, {defender.DefensivePower} DP)");

                //Switch attacking role
                Character temp = attacker;
                attacker = defender;
                defender = temp;
            }
            //Winner!
            DeclareWinner(player1Character, player2Character);
            Console.ReadLine();
        }
        static void DeclareWinner(Character player1Character, Character player2Character)
        {
            Console.WriteLine();
            Console.WriteLine("************");
            Console.WriteLine("GAME OVER");
            Console.WriteLine("************");
            Console.WriteLine();

            if(player1Character.Health > 0)
            {
                System.Console.WriteLine($"{player1Character.Name} ({player1Character.GetType().Name}): {player1Character.GetStats()}");
                System.Console.WriteLine($"{player2Character.Name} ({player2Character.GetType().Name}): {player2Character.GetStats()}");

                Console.ReadLine();
            }
        }
    }
}