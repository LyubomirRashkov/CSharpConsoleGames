using System;

namespace TicTacToe.Utilities
{
    public static class Converter
    {
        public static int[] ConvertToRowAndCol(string input)
        {
            int row;
            int col;

            if (input.Length != 2)
            {
                throw new ArgumentException("Invalid position!");
            }

            if (input[0] == 'a')
            {
                col = 0;
            }
            else if (input[0] == 'b')
            {
                col = 1;
            }
            else if (input[0] == 'c')
            {
                col = 2;
            }
            else
            {
                throw new ArgumentException("Invalid position!");
            }

            if (input[1] == '1')
            {
                row = 2;
            }
            else if (input[1] == '2')
            {
                row = 1;
            }
            else if (input[1] == '3')
            {
                row = 0;
            }
            else
            {
                throw new ArgumentException("Invalid position!");
            }

            return new int[] { row, col };
        }
    }
}
