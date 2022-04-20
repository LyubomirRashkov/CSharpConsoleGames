using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Interfaces;
using TicTacToe.Utilities;
using TicTacToe.Utilities.Enums;

namespace TicTacToe.Models
{
    public class WeakPlayer : IPlayer
    {
        private readonly Random random;

        public WeakPlayer()
        {
            this.random = new Random();
        }

        public Index Play(Board board, Symbols symbol)
        {
            List<Index> worstMoves = new List<Index>();

            int worstMoveValue = int.MinValue;

            List<Index> possibleMoves = board.GetEmptyPositions().ToList();

            foreach (Index possibleMove in possibleMoves)
            {
                Symbols targetWinnerSymbol = symbol == Symbols.X ? Symbols.O : Symbols.X;

                board.PlaceSymbol(possibleMove, symbol);
                int currentMoveValue = MiniMax(board, targetWinnerSymbol, symbol == Symbols.X ? Symbols.O : Symbols.X);
                board.PlaceSymbol(possibleMove, Symbols.None);

                if (currentMoveValue > worstMoveValue)
                {
                    worstMoves.Clear();
                    worstMoves.Add(possibleMove);
                    worstMoveValue = currentMoveValue;
                }
                else if (currentMoveValue == worstMoveValue)
                {
                    worstMoves.Add(possibleMove);
                }
            }

            Index currentMove = worstMoves[this.random.Next(0, worstMoves.Count)];

            return currentMove;
        }

        private int MiniMax(Board board, Symbols targetWinnerSymbol, Symbols currentPlayerSymbol)
        {
            if (GameInfo.IsGameOver(board))
            {
                Symbols winner = GameInfo.GetWinner(board);

                if (winner == targetWinnerSymbol)
                {
                    return 1;
                }
                else if (winner == Symbols.None)
                {
                    return 0;
                }

                return -1;
            }

            int worstValue = targetWinnerSymbol == currentPlayerSymbol ? int.MinValue : int.MaxValue;

            List<Index> possibleMoves = board.GetEmptyPositions().ToList();

            foreach (Index possibleMove in possibleMoves)
            {
                board.PlaceSymbol(possibleMove, currentPlayerSymbol);
                int currentMoveValue = MiniMax(board, targetWinnerSymbol, currentPlayerSymbol == Symbols.O ? Symbols.X
                                                                                                          : Symbols.O);
                board.PlaceSymbol(possibleMove, Symbols.None);

                if (currentPlayerSymbol == targetWinnerSymbol)
                {
                    worstValue = Math.Max(worstValue, currentMoveValue);
                }
                else
                {
                    worstValue = Math.Min(worstValue, currentMoveValue);
                }
            }

            return worstValue;
        }
    }
}
