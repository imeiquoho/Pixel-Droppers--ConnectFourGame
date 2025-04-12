using System;
using ConnectFourGame.Core;

namespace ConnectFourGame.Tests
{
    public static class BoardTests
    {
        public static void RunTests()
        {
            TestCanPlaceToken();
            TestIsFull();
        }

        private static void TestCanPlaceToken()
        {
            Board board = new Board();
            if (board.CanPlaceToken(0))
                Console.WriteLine("✅ CanPlaceToken test passed.");
            else
                Console.WriteLine("❌ CanPlaceToken test failed.");
        }

        private static void TestIsFull()
        {
            Board board = new Board();
            for (int col = 0; col < 7; col++)
                for (int row = 0; row < 6; row++)
                    board.DropToken(col, 'X');

            if (board.IsFull())
                Console.WriteLine("✅ IsFull test passed.");
            else
                Console.WriteLine("❌ IsFull test failed.");
        }
    }
}
