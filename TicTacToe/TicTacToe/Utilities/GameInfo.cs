using TicTacToe.Models;
using TicTacToe.Utilities.Enums;

namespace TicTacToe.Utilities
{
    public static class GameInfo
    {

        public static Symbols GetWinner(Board board)
        {
            Symbols winner;

            for (int row = 0; row < board.BoardState.GetLength(0); row++)
            {
                winner = board.GetRowSymbol(row);

                if (winner != Symbols.None)
                {
                    return winner;
                }
            }

            for (int col = 0; col < board.BoardState.GetLength(1); col++)
            {
                winner = board.GetColSymbol(col);

                if (winner != Symbols.None)
                {
                    return winner;
                }
            }

            winner = board.GetTLBRDiagonalSymbol();

            if (winner != Symbols.None)
            {
                return winner;
            }

            winner = board.GetTRBLDagonalSymbol();

            return winner;
        }

        public static bool IsGameOver(Board board)
        {
            for (int row = 0; row < board.BoardState.GetLength(0); row++)
            {
                Symbols rowSymbol = board.GetRowSymbol(row);

                if (rowSymbol != Symbols.None)
                {
                    return true;
                }
            }

            for (int col = 0; col < board.BoardState.GetLength(1); col++)
            {
                Symbols colSymbol = board.GetColSymbol(col);

                if (colSymbol != Symbols.None)
                {
                    return true;
                }
            }

            Symbols TLBRDiagonalSymbol = board.GetTLBRDiagonalSymbol();

            if (TLBRDiagonalSymbol != Symbols.None)
            {
                return true;
            }

            Symbols TRBLDiagonalSymbol = board.GetTRBLDagonalSymbol();

            if (TRBLDiagonalSymbol != Symbols.None)
            {
                return true;
            }

            return board.IsFull();
        }

        public static string GetFinalStateOfTheBoard(Board board)
        {
            return board.ToString();
        }
    }
}
