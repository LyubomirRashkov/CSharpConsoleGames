using SnakeGame.Core;
using SnakeGame.GameObjects;
using SnakeGame.Utilities;
using System;

namespace SnakeGame
{
    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            PrintTheRules();

            ExecuteTheCommand();
        }

        private static void ExecuteTheCommand()
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

            if (consoleKeyInfo.Key == ConsoleKey.Escape)
            {
                return;
            }
            else
            {
                Console.Clear();

                Wall wall = new Wall(125, 35);

                Snake snake = new Snake(wall);

                Engine engine = new Engine(snake);
                engine.Run();
            }
        }

        private static void PrintTheRules() 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(60,3);
            Console.WriteLine("Hi, this is the old Snake game!");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(50,6);
            Console.WriteLine("Before you continue pay attention to these advices:");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0,8);
            Console.WriteLine("   1. There are two kinds of food - sample food and special food. A piece of sample food gives you one point and your snake grows with one piece.");
            Console.WriteLine("      A piece of special food gives you three points and your snake grows with three pieces. All foods will be white.");
            Console.WriteLine();
            Console.WriteLine("   2. Every time you eat reach a food a piece of wall will appear somewhere in the lair. Be carefull, if your snake hit a wall it dies...");
            Console.WriteLine();
            Console.WriteLine("   3. Every piece of food disappears after some time and another piece of food will appear somewhere in the lair.");
            Console.WriteLine();
            Console.WriteLine("   4. The lair is under magic, so your snake will move faster in vertical direction and will look like a zebra.");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   Press any key to start a game or Esc for exit");
        }
    }
}
