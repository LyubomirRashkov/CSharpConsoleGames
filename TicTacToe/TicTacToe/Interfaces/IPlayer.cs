using TicTacToe.Models;
using TicTacToe.Utilities.Enums;

namespace TicTacToe.Interfaces
{
    public interface IPlayer
    {
        Index Play(Board board, Symbols symbol);
    }
}
