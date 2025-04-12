using System;

namespace ConnectFourGame.Core
{
    public class Game
    {
        private Board board;
        private Player currentPlayer;

        public Game()
        {
            board = new Board();
        }

        public void Start(Player player1, Player player2)
        {
            currentPlayer = player1;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Current Board:");
                board.DisplayBoard();

                int column = currentPlayer.ChooseColumn(board);
                if (column < 0 || column > 6 || !board.DropToken(column, currentPlayer.Token))
                {
                    Console.WriteLine("Invalid move. Try again.");
                    continue;
                }

                if (board.CheckWin(currentPlayer.Token))
                {
                    Console.Clear();
                    board.DisplayBoard();
                    Console.WriteLine($"{currentPlayer.Name} wins!");
                    break;
                }

                if (board.IsFull())
                {
                    Console.Clear();
                    board.DisplayBoard();
                    Console.WriteLine("It's a draw!");
                    break;
                }

                currentPlayer = (currentPlayer == player1) ? player2 : player1;
            }
        }
    }
}
