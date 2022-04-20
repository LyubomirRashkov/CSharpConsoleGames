using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Interfaces;
using TicTacToe.Utilities.Enums;

namespace TicTacToe.Models
{
    public class RandomPlayer : IPlayer
    {
        private readonly Random random;

        public RandomPlayer()
        {
            this.random = new Random();
        }

        public Index Play(Board board, Symbols symbol)
        {
            List<Index> emptyPositions = board.GetEmptyPositions().ToList();

            Index move = emptyPositions[random.Next(0, emptyPositions.Count)];

            return move;
        }
    }
}
