using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Interfaces;
using TicTacToe.Utilities;
using TicTacToe.Utilities.Enums;

namespace TicTacToe.Models
{
    public class AIPlayer : IPlayer
    {
        private readonly Random random;

        public AIPlayer()
        {
            this.random = new Random();
        }

        public Index Play(Board board, Symbols symbol)
        {
            List<Index> bestMoves = new List<Index>();

            int bestMoveValue = int.MinValue;

            List<Index> possibleMoves = board.GetEmptyPositions().ToList();

            foreach (Index possibleMove in possibleMoves)
            {
                board.PlaceSymbol(possibleMove, symbol);
                int currentMoveValue = MiniMax(board, symbol, symbol == Symbols.X ? Symbols.O : Symbols.X);
                board.PlaceSymbol(possibleMove, Symbols.None);

                if (currentMoveValue > bestMoveValue)
                {
                    bestMoves.Clear();
                    bestMoves.Add(possibleMove);
                    bestMoveValue = currentMoveValue;
                }
                else if (currentMoveValue == bestMoveValue)
                {
                    bestMoves.Add(possibleMove);
                }
            }

            Index currentMove = bestMoves[this.random.Next(0, bestMoves.Count)];

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

            int bestValue = targetWinnerSymbol == currentPlayerSymbol ? int.MinValue : int.MaxValue;

            List<Index> possibleMoves = board.GetEmptyPositions().ToList();

            foreach (Index possibleMove in possibleMoves)
            {
                board.PlaceSymbol(possibleMove, currentPlayerSymbol);
                int currentMoveValue = MiniMax(board, targetWinnerSymbol, currentPlayerSymbol == Symbols.O ? Symbols.X 
                                                                                                          : Symbols.O);
                board.PlaceSymbol(possibleMove, Symbols.None);

                if (currentPlayerSymbol == targetWinnerSymbol)
                {
                    bestValue = Math.Max(bestValue, currentMoveValue);
                }
                else
                {
                    bestValue = Math.Min(bestValue, currentMoveValue);
                }
            }

            return bestValue;
        }
    }
}
