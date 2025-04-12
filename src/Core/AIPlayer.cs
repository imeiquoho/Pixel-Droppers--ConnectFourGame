using System;

namespace ConnectFourGame.Core
{
    public class AIPlayer : Player
    {
        private static Random _random = new Random();

        public AIPlayer(string name, char token) : base(name, token) { }

        public override int ChooseColumn(Board board)
        {
            int column;
            do
            {
                column = _random.Next(0, 7);  // random column between 0 and 6
            } while (!board.CanPlaceToken(column));

            Console.WriteLine($"{Name} (AI) chooses column {column}");
            return column;
        }
    }
}
