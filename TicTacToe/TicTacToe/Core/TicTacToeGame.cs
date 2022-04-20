using TicTacToe.Interfaces;
using TicTacToe.Models;
using TicTacToe.Utilities;
using TicTacToe.Utilities.Enums;

namespace TicTacToe.Core
{
    public class TicTacToeGame
    {
        private readonly ConsoleWriter writer;
        private Board board;
        private IPlayer firstPlayer;
        private IPlayer secondPlayer;

        public TicTacToeGame(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            this.writer = new ConsoleWriter();
            this.Board = new Board();
            this.FirstPlayer = firstPlayer;
            this.SecondPlayer = secondPlayer;
        }

        public IPlayer FirstPlayer
        {
            get => this.firstPlayer;
            private set => this.firstPlayer = value;
        }

        public IPlayer SecondPlayer
        {
            get => this.secondPlayer;
            private set => this.secondPlayer = value;
        }

        public Board Board 
        {
            get => this.board;
            private set => this.board = value; 
        }

        public void Play()
        {
            this.writer.WriteLine(this.Board.ToString());

            IPlayer currentPlayer = this.FirstPlayer;
            Symbols symbol = Symbols.X;

            while (!GameInfo.IsGameOver(this.Board))
            {
                Index currentMove = currentPlayer.Play(this.Board, symbol);
                this.Board.PlaceSymbol(currentMove, symbol);
                System.Console.WriteLine(this.Board.ToString());

                if (currentPlayer == this.FirstPlayer)
                {
                    currentPlayer = this.SecondPlayer;
                    symbol = Symbols.O;
                }
                else
                {
                    currentPlayer = this.FirstPlayer;
                    symbol = Symbols.X;
                }
            }
        }
    }
}
