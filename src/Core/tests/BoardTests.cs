using System;
using ConnectFourGame.Core;

namespace ConnectFourGame.Tests.Core
{
    public class BoardTests
    {
        public static void TestDropToken()
        {
            var board = new Board();
            bool result = board.DropToken(0, 'X');
            Console.WriteLine(result ? "DropToken Test Passed" : "DropToken Test Failed");
        }

        public static void TestIsFull()
        {
            var board = new Board();
            for (int i = 0; i < 6; i++) board.DropToken(0, 'X');
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 6; j++)
                    board.DropToken(i, 'O');

            Console.WriteLine(board.IsFull() ? "IsFull Test Passed" : "IsFull Test Failed");
        }

        public static void RunAll()
        {
            TestDropToken();
            TestIsFull();
        }
    }
}

