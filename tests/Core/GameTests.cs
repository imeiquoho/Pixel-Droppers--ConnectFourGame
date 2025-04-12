using ConnectFourGame;
using ConnectFourGame.Core;

namespace ConnectFourGame.Tests.Core
{
    public class GameTests
    {
        public static void TestGameStartDraw()
        {
            Console.WriteLine("Simulating game draw...");

            var board = new Board();
            for (int col = 0; col < 7; col++)
            {
                char token = (col % 2 == 0) ? 'X' : 'O';
                for (int row = 0; row < 6; row++)
                {
                    board.DropToken(col, token);
                }
            }

            Console.WriteLine(board.IsFull() && !board.CheckWin('X') && !board.CheckWin('O') ? "GameDraw Test Passed" : "GameDraw Test Failed");
        }

        public static void RunAll()
        {
            TestGameStartDraw();
        }
    }
}
