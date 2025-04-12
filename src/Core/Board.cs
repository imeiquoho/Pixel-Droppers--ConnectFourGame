using System;

namespace ConnectFourGame.Core
{
    public class Board
    {
        private const int Rows = 6;
        private const int Cols = 7;
        private char[,] grid = new char[Rows, Cols];

        public Board()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    grid[i, j] = '.';
        }

        public void DisplayBoard()
        {
            Console.WriteLine("\nCurrent Board:");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                    Console.Write(grid[i, j] + " ");
                Console.WriteLine();
            }
        }

        public bool CanPlaceToken(int column)
        {
            return grid[0, column] == '.';
        }

        public void DropToken(int column, char token)
        {
            for (int row = Rows - 1; row >= 0; row--)
            {
                if (grid[row, column] == '.')
                {
                    grid[row, column] = token;
                    break;
                }
            }
        }

        public bool CheckWin(char token)
        {
            // Check horizontal
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Cols - 3; col++)
                    if (grid[row, col] == token && grid[row, col + 1] == token &&
                        grid[row, col + 2] == token && grid[row, col + 3] == token)
                        return true;

            // Check vertical
            for (int row = 0; row < Rows - 3; row++)
                for (int col = 0; col < Cols; col++)
                    if (grid[row, col] == token && grid[row + 1, col] == token &&
                        grid[row + 2, col] == token && grid[row + 3, col] == token)
                        return true;

            // Check diagonals (bottom-left to top-right)
            for (int row = 3; row < Rows; row++)
                for (int col = 0; col < Cols - 3; col++)
                    if (grid[row, col] == token && grid[row - 1, col + 1] == token &&
                        grid[row - 2, col + 2] == token && grid[row - 3, col + 3] == token)
                        return true;

            // Check diagonals (top-left to bottom-right)
            for (int row = 0; row < Rows - 3; row++)
                for (int col = 0; col < Cols - 3; col++)
                    if (grid[row, col] == token && grid[row + 1, col + 1] == token &&
                        grid[row + 2, col + 2] == token && grid[row + 3, col + 3] == token)
                        return true;

            return false;
        }

        public bool IsFull()
        {
            for (int col = 0; col < Cols; col++)
                if (grid[0, col] == '.')
                    return false;
            return true;
        }
    }
}
