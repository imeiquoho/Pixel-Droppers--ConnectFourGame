using System;

namespace ConnectFourGame.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Connect Four!");
            Console.Write("Enter name for Player 1: ");
            string name1 = Console.ReadLine();

            Console.Write("Do you want to play against (1) another human or (2) AI? Enter 1 or 2: ");
            string choice = Console.ReadLine();

            Player player1 = new HumanPlayer(name1, 'X');
            Player player2;

            if (choice == "1")
            {
                Console.Write("Enter name for Player 2: ");
                string name2 = Console.ReadLine();
                player2 = new HumanPlayer(name2, 'O');
            }
            else
            {
                player2 = new AIPlayer("Computer", 'O');
            }

            var game = new Game();
            game.Start(player1, player2);
        }
    }
}
