using System;
using TicTacToe.Core;
using TicTacToe.Models;
using TicTacToe.Utilities;

namespace TicTacToe
{
    public class StartUp
    {
        static void Main()
        {
            Console.Title = Messages.Title;

            Engine engine = new Engine(new ConsoleReader(), new ConsoleWriter());

            engine.Run();
        }
    }
}
