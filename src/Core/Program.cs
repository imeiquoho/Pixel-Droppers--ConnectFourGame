using System;
using ConnectFourGame.Core;

namespace ConnectFourGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter name for Player 1 (X): ");
            string name1 = Console.ReadLine();
            Console.Write("Enter name for Player 2 (O): ");
            string name2 = Console.ReadLine();

            Player player1 = new HumanPlayer(name1, 'X');
            Player player2 = new HumanPlayer(name2, 'O');

            Game game = new Game();
            game.Start(player1, player2);

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
