using ConnectFourGame.Core;

namespace ConnectFourGame
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Game game = new Game();
                game.Start();
            }
            while (GameMenu.AskToPlayAgain());

            Console.WriteLine("Thanks for playing!");
        }
    }
}
