using System;

namespace ConnectFourGame.Core
{
    public static class InputHandler
    {
        public static int GetValidatedColumnInput(int boardWidth, Func<int, bool> isColumnFull)
        {
            while (true)
            {
                Console.Write($"Choose a column (0 to {boardWidth - 1}): ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("⚠️  Input cannot be empty.");
                    continue;
                }

                if (!int.TryParse(input, out int column))
                {
                    Console.WriteLine("🚫 Invalid input. Please enter a number.");
                    continue;
                }

                if (column < 0 || column >= boardWidth)
                {
                    Console.WriteLine($"❗ Column must be between 0 and {boardWidth - 1}.");
                    continue;
                }

                if (isColumnFull(column))
                {
                    Console.WriteLine("🛑 That column is full. Choose another one.");
                    continue;
                }

                return column;
            }
        }

    }
}
