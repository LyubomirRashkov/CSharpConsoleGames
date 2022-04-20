using System;
using TicTacToe.Interfaces;

namespace TicTacToe.Models
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string str)
        {
            Console.Write(str);
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
    }
}
