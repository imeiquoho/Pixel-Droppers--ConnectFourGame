using System;

namespace ConnectFourGame.Core
{
    public static class Game
    {
        public static void Start(Player player1, Player player2)
        {
            Board board = new Board();
            Player currentPlayer = player1;
            board.DisplayBoard();

            while (true)
            {
                int column = currentPlayer.ChooseColumn(board);
                if (column >= 0 && column < 7 && board.CanPlaceToken(column))
                {
                    board.DropToken(column, currentPlayer.Token);
                    board.DisplayBoard();

                    if (board.CheckWin(currentPlayer.Token))
                    {
                        Console.WriteLine($"\n🎉 {currentPlayer.Name} wins!");
                        break;
                    }

                    if (board.IsFull())
                    {
                        Console.WriteLine("\nIt's a draw!");
                        break;
                    }

                    currentPlayer = currentPlayer == player1 ? player2 : player1;
                }
                else
                {
                    Console.WriteLine("Invalid column. Try again.");
                }
            }
        }
    }
}
