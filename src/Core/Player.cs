// Player.cs
using System;

namespace ConnectFourGame.Core
{
    public abstract class Player
    {
        public string Name { get; set; }
        public char Token { get; set; }

        public Player(string name, char token)
        {
            Name = name;
            Token = token;
        }

        public abstract int ChooseColumn(Board board);
    }
}
