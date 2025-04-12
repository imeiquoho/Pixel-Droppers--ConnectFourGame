using System;
using ConnectFourGame.Core;

namespace ConnectFourGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new HumanPlayer("Player 1", 'X');
            Player player2 = new AIPlayer("Computer", 'O');

            Game.Start(player1, player2);
        }
    }
}
