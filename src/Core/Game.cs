using System;

namespace ConnectFourGame.Core
{
    public class Game
    {
        private Board board = new Board();
        private Player currentPlayer;

        public void Start(Player player1, Player player2)
        {
            currentPlayer = player1;

            while (true)
            {
                Console.Clear();
                board.DisplayBoard();

                int column = currentPlayer.ChooseColumn(board);
                if (column < 0 || column > 6 || !board.CanPlaceToken(column))
                {
                    Console.WriteLine("Invalid move. Try again.");
                    continue;
                }

                board.DropToken(column, currentPlayer.Token);

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
