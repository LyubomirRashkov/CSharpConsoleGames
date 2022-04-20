using System.Collections.Generic;
using TicTacToe.Models;
using TicTacToe.Utilities.Enums;

namespace TicTacToe.Interfaces
{
    public interface IBoard
    {
        bool IsFull();

        void PlaceSymbol(Index index, Symbols symbol);

        IEnumerable<Index> GetEmptyPositions();

        Symbols GetRowSymbol(int row);

        Symbols GetColSymbol(int col);

        Symbols GetTLBRDiagonalSymbol();

        Symbols GetTRBLDagonalSymbol();
    }
}
