using System;
using TicTacToe.Interfaces;

namespace TicTacToe.Models
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
