using System;

namespace ConnectFourGame.Tests
{
    public static class TestHelpers
    {
        public static void PrintHeader(string testName)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n--- Running {testName} ---");
            Console.ResetColor();
        }

        public static void PrintResult(bool passed)
        {
            Console.ForegroundColor = passed ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(passed ? "✅ Test Passed" : "❌ Test Failed");
            Console.ResetColor();
        }
    }
}
