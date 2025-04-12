using System;

namespace ConnectFourGame.Core
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, char token) : base(name, token) { }

        public override int ChooseColumn(Board board)
        {
            int column;
            while (true)
            {
                Console.Write($"{Name}, enter a column number (0-6): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out column) && column >= 0 && column <= 6)
                {
                    if (board.CanPlaceToken(column))
                    {
                        return column;
                    }
                    Console.WriteLine("That column is full. Try a different one.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 6.");
                }
            }
        }
    }
}
