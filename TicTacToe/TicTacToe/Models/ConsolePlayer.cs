using System.Linq;
using TicTacToe.Interfaces;
using TicTacToe.Utilities;
using TicTacToe.Utilities.Enums;

namespace TicTacToe.Models
{
    public class ConsolePlayer : IPlayer
    {
        private readonly ConsoleReader reader;
        private readonly ConsoleWriter writer;

        public ConsolePlayer()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public Index Play(Board board, Symbols symbol)
        {
            Index position = null;

            while (true)
            {
                writer.WriteLine(string.Format(Messages.TurnInfo, symbol.ToString()));

                string move = reader.ReadLine();

                try
                {
                    int[] targetMove = Converter.ConvertToRowAndCol(move);
                    position = new Index(targetMove);
                }
                catch
                {
                    writer.WriteLine(Messages.InvalidMove);
                    continue;
                }

                if (position.Row < 0 || position.Row >= board.BoardState.GetLength(0)
                    || position.Col < 0 || position.Col >= board.BoardState.GetLength(1))
                {
                    writer.WriteLine(Messages.OutsideTheBoard);
                    continue;
                }

                if (!board.GetEmptyPositions().Any(p => p.Equals(position)))
                {
                    writer.WriteLine(Messages.PositionNotFree);
                    continue;
                }

                writer.WriteLine("");

                break;
            }

            return position;
        }
    }
}
