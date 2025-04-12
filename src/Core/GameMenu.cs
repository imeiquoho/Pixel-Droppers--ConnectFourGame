using System;

namespace ConnectFourGame.Core
{
    public static class GameMenu
    {
        public static bool AskToPlayAgain()
        {
            Console.Write("\nWould you like to play again? (y/n): ");
            string input = Console.ReadLine()?.Trim().ToLower();

            while (input != "y" && input != "n")
            {
                Console.Write("Invalid input. Please enter 'y' or 'n': ");
                input = Console.ReadLine()?.Trim().ToLower();
            }

            return input == "y";
        }
    }
}
