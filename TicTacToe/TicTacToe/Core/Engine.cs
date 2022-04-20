using System;
using TicTacToe.Interfaces;
using TicTacToe.Models;
using TicTacToe.Utilities;
using TicTacToe.Utilities.Enums;

namespace TicTacToe.Core
{
    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private Players players;
        private Turns turn;
        private Difficulties difficulty;
        private GameOptions gameOption;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                IPlayer firstPlayer = null;
                IPlayer secondPlayer = null;

                this.writer.WriteLine(Messages.ChooseOption);
                this.writer.WriteLine(Messages.Option1);
                this.writer.WriteLine(Messages.Option2);

                string option = this.reader.ReadLine();

                bool isCorrectOption = Enum.TryParse(option, out this.players);

                while (!isCorrectOption)
                {
                    this.writer.WriteLine(Messages.InvalidChoise);
                    this.writer.WriteLine(Messages.ChooseOption);
                    this.writer.WriteLine(Messages.Option1);
                    this.writer.WriteLine(Messages.Option2);

                    option = this.reader.ReadLine();

                    isCorrectOption = Enum.TryParse(option, out this.players);
                }

                if (players == Players.m)
                {
                    firstPlayer = new ConsolePlayer();
                    secondPlayer = new ConsolePlayer();

                    this.writer.WriteLine(Messages.PlayWithAFriend);
                    this.writer.WriteLine(Messages.FirstPlayerSymbol);
                    this.writer.WriteLine(Messages.SecondPlayerSymbol);
                    this.writer.WriteLine(Messages.PlayersChoise);
                    this.writer.WriteLine(string.Empty);
                }
                else
                {
                    this.writer.WriteLine(Messages.PlayWithTheComputer);
                    this.writer.WriteLine(Messages.ChooseTurn);

                    string inputTurn = this.reader.ReadLine();

                    bool isCorrectTurn = Enum.TryParse(inputTurn, out this.turn);

                    while (!isCorrectTurn)
                    {
                        this.writer.WriteLine(Messages.InvalidChoise);
                        this.writer.WriteLine(Messages.ChooseTurn);

                        inputTurn = this.reader.ReadLine();

                        isCorrectTurn = Enum.TryParse(inputTurn, out this.turn);
                    }

                    if (turn == Turns.f)
                    {
                        this.writer.WriteLine(Messages.ChooseToBeFirst);
                    }
                    else
                    {
                        this.writer.WriteLine(Messages.ChooseToBeSecond);
                    }

                    this.writer.WriteLine(Messages.ChooseDifficulty);
                    this.writer.WriteLine(Messages.DifficultyEasy);
                    this.writer.WriteLine(Messages.DifficultyMedium);
                    this.writer.WriteLine(Messages.DifficultyHard);

                    string inputDifficulty = this.reader.ReadLine();

                    bool isCorrectDifficulty = Enum.TryParse(inputDifficulty, out this.difficulty);

                    while (!isCorrectDifficulty)
                    {
                        this.writer.WriteLine(Messages.InvalidChoise);
                        this.writer.WriteLine(Messages.ChooseDifficulty);
                        this.writer.WriteLine(Messages.DifficultyEasy);
                        this.writer.WriteLine(Messages.DifficultyMedium);
                        this.writer.WriteLine(Messages.DifficultyHard);

                        inputDifficulty = this.reader.ReadLine();

                        isCorrectDifficulty = Enum.TryParse(inputDifficulty, out this.difficulty);
                    }

                    this.writer.WriteLine(string.Empty);

                    if (this.turn == Turns.f)
                    {
                        firstPlayer = new ConsolePlayer();

                        if (this.difficulty == Difficulties.e)
                        {
                            secondPlayer = new WeakPlayer();
                        }
                        else if (this.difficulty == Difficulties.m)
                        {
                            secondPlayer = new RandomPlayer();
                        }
                        else if (this.difficulty == Difficulties.h)
                        {
                            secondPlayer = new AIPlayer();
                        }
                    }
                    else
                    {
                        secondPlayer = new ConsolePlayer();

                        if (this.difficulty == Difficulties.e)
                        {
                            firstPlayer = new WeakPlayer();
                        }
                        else if (this.difficulty == Difficulties.m)
                        {
                            firstPlayer = new RandomPlayer();
                        }
                        else if (this.difficulty == Difficulties.h)
                        {
                            firstPlayer = new AIPlayer();
                        }
                    }
                }

                PlayGame(firstPlayer, secondPlayer);

                this.writer.WriteLine(Messages.StartANewGame);
                this.writer.WriteLine(Messages.ExitApplication);

                string newGame = this.reader.ReadLine();

                bool IsCorrectGameOption = Enum.TryParse(newGame, out this.gameOption);

                while (!IsCorrectGameOption)
                {
                    this.writer.WriteLine(Messages.InvalidChoise);
                    this.writer.WriteLine(Messages.StartANewGame);
                    this.writer.WriteLine(Messages.ExitApplication);

                    newGame = this.reader.ReadLine();

                    IsCorrectGameOption = Enum.TryParse(newGame, out this.gameOption);
                }

                if (this.gameOption == GameOptions.exit)
                {
                    return;
                }
                else
                {
                    continue;
                }
            }
        }
        private void PlayGame(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            TicTacToeGame game = new(firstPlayer, secondPlayer);

            game.Play();

            this.writer.WriteLine(Messages.GameOver);

            Symbols winnerSymbol = GameInfo.GetWinner(game.Board);

            if (winnerSymbol == Symbols.None)
            {
                this.writer.WriteLine(Messages.NoWinner);
            }
            else
            {
                this.writer.WriteLine(string.Format(Messages.Winner, winnerSymbol));
            }

            this.writer.WriteLine(GameInfo.GetFinalStateOfTheBoard(game.Board));
        }
    }
}
