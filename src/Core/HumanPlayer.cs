using System;

namespace ConnectFourGame.Core
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(char token) : base(token) { }

        public override int GetMove(Board board)
        {
            int column;

            while (true)
            {
                Console.Write($"Player {Token}, choose a column (0-6): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out column))
                {
                    return column;
                }
                else
                {
                    Console.WriteLine("⚠️ Invalid input. Please enter a number between 0 and 6.");
                }
            }
        }
    }
}
