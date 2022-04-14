using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame.GameObjects
{
    public abstract class Food : Point
    {
        private readonly Wall wall;
        private readonly char symbol;
        private readonly Random random;

        protected Food(Wall wall, char symbol, int points) 
            : base(0, 0)
        {
            this.wall = wall;
            this.symbol = symbol;
            this.Points = points;

            this.random = new Random();
        }

        public int Points { get; private set; }

        public void PlaceOnARandomPosition(Snake snake, Queue<Point> snakeElements, IEnumerable<int[]> bricks) 
        {
            this.X = this.random.Next(1, this.wall.X);
            this.Y = this.random.Next(1, this.wall.Y);

            if (IsPositionInvalid(this.X, this.Y, snakeElements, bricks))
            {
                this.PlaceOnARandomPosition(snake,snakeElements , bricks);
            }

            snake.LastFood = new Point(this.X, this.Y);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta;
            this.Draw(symbol);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private bool IsPositionInvalid(int x, int y, IEnumerable<Point> points, IEnumerable<int[]> bricks)
        {
            return (points.Any(p => p.X == x && p.Y == y) || bricks.Any(b => b[0] == x && b[1] == y));
        }
    }
}
