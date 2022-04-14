using SnakeGame.Enums;
using SnakeGame.GameObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeGame.Core
{
    public class Engine
    {
        private const int FoodLastingTime = 2000;

        private readonly Snake snake;
        private readonly Dictionary<Direction, Point> nextPointByDirection;

        private Direction direction;

        public Engine(Snake snake)
        {
            this.snake = snake;
            this.direction = Direction.Right;

            this.nextPointByDirection = new Dictionary<Direction, Point>
            {
                { Direction.Left, new Point(-1, 0) },
                { Direction.Right, new Point(1, 0) },
                { Direction.Up, new Point(0, -1) },
                { Direction.Down, new Point(0, 1) }
            };
        }

        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(40, 37);
            Console.WriteLine("Use the arrow keys to move the snake");
            Console.SetCursorPosition(40, 38);
            Console.WriteLine("To pause the game left click with your mouse");
            Console.SetCursorPosition(40, 39);
            Console.WriteLine("To resume press any key");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.SetCursorPosition(0, 40);

                if (Console.KeyAvailable)
                {
                    this.GetDirection();
                }

                bool isMoveAllowed = this.snake.TryMove(this.nextPointByDirection[this.direction]);

                if (!isMoveAllowed)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(65, 20);
                    Console.WriteLine("Oh, you died...");
                    Console.SetCursorPosition(65, 21);
                    Console.WriteLine($"Your score: {this.snake.Points}");
                    Console.SetCursorPosition(65, 22);
                    Console.WriteLine($"Your level: {this.snake.Level}");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(57, 25);
                    Console.WriteLine("To start a new game press any key");
                    Console.SetCursorPosition(57, 26);
                    Console.WriteLine("To exit the application press Esc");
                    Console.ForegroundColor = ConsoleColor.White;

                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

                    if (consoleKeyInfo.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.Clear();

                        Wall wall = new Wall(125, 35);

                        Snake snake = new Snake(wall);

                        Engine engine = new Engine(snake);
                        engine.Run();
                    }
                }

                if (Environment.TickCount % FoodLastingTime == 0)
                {
                    Point previousFood = this.snake.LastFood;

                    Console.SetCursorPosition(previousFood.X, previousFood.Y);
                    Console.Write(' ');

                    this.snake.PlaceANewFood();
                }

                Thread.Sleep(200);
            }
        }

        private void GetDirection()
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

            if (consoleKeyInfo.Key == ConsoleKey.LeftArrow && this.direction != Direction.Right)
            {
                this.direction = Direction.Left;
            }
            else if (consoleKeyInfo.Key == ConsoleKey.RightArrow && this.direction != Direction.Left)
            {
                this.direction = Direction.Right;
            }
            else if (consoleKeyInfo.Key == ConsoleKey.UpArrow && this.direction != Direction.Down)
            {
                this.direction = Direction.Up;
            }
            else if (consoleKeyInfo.Key == ConsoleKey.DownArrow && this.direction != Direction.Up)
            {
                this.direction = Direction.Down;
            }
        }
    }
}
