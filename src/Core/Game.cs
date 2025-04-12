using System;
using ConnectFourGame.src.Core;

namespace ConnectFourGame
{
    public class Game
    {
        private Board board;
        private Player player1;
        private Player player2;
        private Player currentPlayer;

        public Game()
        {
            board = new Board();
            player1 = new HumanPlayer('X');
            player2 = new AIPlayer('O');
            currentPlayer = player1;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Connect Four!");
            board.Render();

            while (!board.IsFull())
            {
                Console.WriteLine($"Player {currentPlayer.Token}'s turn");

                int column = -1;
                bool validMove = false;

                while (!validMove)
                {
                    try
                    {
                        column = currentPlayer.GetMove(board);

                        if (column < 0 || column >= 7)
                        {
                            Console.WriteLine("⚠️ Invalid column. Please choose a number between 0 and 6.");
                            continue;
                        }

                        if (!board.CanPlaceToken(column))
                        {
                            Console.WriteLine("⚠️ That column is full. Please choose a different one.");
                            continue;
                        }

                        validMove = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("⚠️ Invalid input. Please enter a number.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"⚠️ Unexpected error: {ex.Message}");
                    }
                }

                board.DropToken(column, currentPlayer.Token);
                board.Render();

                if (board.CheckWin(currentPlayer.Token))
                {
                    Console.WriteLine($"🎉 Player {currentPlayer.Token} wins!");
                    return;
                }

                currentPlayer = (currentPlayer == player1) ? player2 : player1;
            }

            Console.WriteLine("It's a draw!");
        }
    }
}
