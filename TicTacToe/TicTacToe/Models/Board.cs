using System.Collections.Generic;
using System.Text;
using TicTacToe.Interfaces;
using TicTacToe.Utilities.Enums;

namespace TicTacToe.Models
{
    public class Board : IBoard
    {
        private const int DefaultSize = 3;

        private Symbols[,] board;

        public Board()
        {
            this.BoardState = new Symbols[DefaultSize, DefaultSize];
        }

        public Symbols[,] BoardState
        {
            get => this.board;
            private set => this.board = value;
        }

        public void PlaceSymbol(Index index, Symbols symbol)
        {
            this.BoardState[index.Row, index.Col] = symbol;
        }

        public bool IsFull()
        {
            for (int row = 0; row < this.BoardState.GetLength(0); row++)
            {
                for (int col = 0; col < this.BoardState.GetLength(1); col++)
                {
                    if (this.BoardState[row, col] == Symbols.None)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public IEnumerable<Index> GetEmptyPositions()
        {
            List<Index> emptyPositions = new();

            for (int row = 0; row < this.BoardState.GetLength(0); row++)
            {
                for (int col = 0; col < this.BoardState.GetLength(1); col++)
                {
                    if (this.BoardState[row, col] == Symbols.None)
                    {
                        Index freePosition = new Index(row, col);

                        emptyPositions.Add(freePosition);
                    }
                }
            }

            return emptyPositions;
        }

        public Symbols GetRowSymbol(int row)
        {
            Symbols symbol = this.board[row, 0];

            if (symbol == Symbols.None)
            {
                return Symbols.None;
            }

            for (int col = 1; col < this.BoardState.GetLength(1); col++)
            {
                if (symbol != this.BoardState[row, col])
                {
                    return Symbols.None;
                }
            }

            return symbol;
        }

        public Symbols GetColSymbol(int col)
        {
            Symbols symbol = this.BoardState[0, col];

            if (symbol == Symbols.None)
            {
                return Symbols.None;
            }

            for (int row = 1; row < this.BoardState.GetLength(0); row++)
            {
                if (symbol != this.BoardState[row, col])
                {
                    return Symbols.None;
                }
            }

            return symbol;
        }

        public Symbols GetTLBRDiagonalSymbol()
        {
            Symbols symbol = this.BoardState[0, 0];

            if (symbol == Symbols.None)
            {
                return Symbols.None;
            }

            for (int i = 1; i < this.BoardState.GetLength(0); i++)
            {
                if (symbol != this.BoardState[i, i])
                {
                    return Symbols.None;
                }
            }

            return symbol;
        }

        public Symbols GetTRBLDagonalSymbol()
        {
            Symbols symbol = this.BoardState[0, this.BoardState.GetLength(1) - 1];

            if (symbol == Symbols.None)
            {
                return Symbols.None;
            }

            for (int i = 1; i < this.BoardState.GetLength(0); i++)
            {
                if (symbol != this.BoardState[i, this.BoardState.GetLength(1) - 1 - i])
                {
                    return Symbols.None;
                }
            }

            return symbol;
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            for (int row = 0; row < this.BoardState.GetLength(0); row++)
            {
                if (row == 0)
                {
                    sb.Append("3 ");
                }
                else if (row == 1)
                {
                    sb.Append("2 ");

                }
                else
                {
                    sb.Append("1 ");
                }

                for (int col = 0; col < this.BoardState.GetLength(1); col++)
                {
                    if (this.BoardState[row, col] == Symbols.None)
                    {
                        sb.Append(". ");
                    }
                    else
                    {
                        sb.Append(this.BoardState[row, col] + " ");
                    }
                }

                sb.AppendLine();
            }

            sb.AppendLine("  a b c ");

            return sb.ToString();
        }
    }
}
