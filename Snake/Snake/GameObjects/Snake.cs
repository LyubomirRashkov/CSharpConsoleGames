using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame.GameObjects
{
    public class Snake
    {
        private const char SnakeBodySymbol = '\u25A0';

        private readonly Food[] foods;
        private readonly Wall wall;
        private readonly Random random;

        private Queue<Point> snake;
        private int foodIndex;
        private List<int[]> bricks;
        private Point lastFood;
        private int points;
        private int level;
        private int neededPoints;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.foods = new Food[]
                {
                    new SimpleFood(this.wall),
                    new SpecialFood(this.wall)
                };
            this.Points = 0;
            this.Level = 1;
            this.neededPoints = 9;

            this.random = new Random();
            this.bricks = new List<int[]>();

            this.CreateSnake();
        }

        public IReadOnlyCollection<int[]> Bricks => this.bricks.AsReadOnly();

        public Point LastFood
        {
            get
            {
                return this.lastFood;
            }
            set
            {
                this.lastFood = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }
            private set
            {
                this.points = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }
            private set
            {
                this.level = value;
            }
        }

        public bool TryMove(Point point)
        {
            Point snakeHead = this.snake.Last();

            int nextX = snakeHead.X + point.X;
            int nextY = snakeHead.Y + point.Y;

            bool isSnake = this.snake.Any(el => el.X == nextX && el.Y == nextY);

            if (isSnake)
            {
                return false;
            }

            bool isWall = (nextX == 0 || nextY == 0 || nextX == this.wall.X || nextY == this.wall.Y);

            if (isWall)
            {
                return false;
            }

            if (this.Bricks.Any(br => br[0] == nextX && br[1] == nextY))
            {
                return false;
            }

            bool isFood = (nextX == this.foods[this.foodIndex].X && nextY == this.foods[foodIndex].Y);

            if (isFood)
            {
                this.Eat(nextX, nextY);
            }

            Point newSnakeHead = new Point(nextX, nextY);
            this.snake.Enqueue(newSnakeHead);
            newSnakeHead.Draw('=');
            snakeHead.Draw(SnakeBodySymbol);

            Point lastPoint = this.snake.Dequeue();
            lastPoint.Draw(' ');

            return true;
        }

        public void PlaceANewFood()
        {
            this.foodIndex = GetRandomIndex();

            this.foods[this.foodIndex].PlaceOnARandomPosition(this, this.snake, this.Bricks);
        }

        private int GetRandomIndex() => new Random().Next(0, this.foods.Length);

        private void Eat(int nextX, int nextY)
        {
            Food food = this.foods[this.foodIndex];

            for (int i = 1; i <= food.Points; i++)
            {
                this.snake.Enqueue(new Point(nextX, nextY));
            }

            this.points += food.Points;
            this.PrintInfo();

            this.CreateAWallBrick(this);

            this.PlaceANewFood();
        }

        private void CreateAWallBrick(Snake snake)
        {
            int x = this.random.Next(1, this.wall.X);
            int y = this.random.Next(1, this.wall.Y);

            if (IsPositionInvalid(x, y, this, this.Bricks))
            {
                this.CreateAWallBrick(this);
            }

            int[] brickCoordinate = new int[] { x, y };
            this.bricks.Add(brickCoordinate);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Blue;
            this.wall.Draw(x, y, '\u25A0');
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

        }

        private bool IsPositionInvalid(int x, int y, Snake snake, IReadOnlyCollection<int[]> bricks)
        {
            return (snake.snake.Any(p => p.X == x && p.Y == y) || bricks.Any(br => br[0] == x && br[1] == y));
        }

        private void CreateSnake()
        {
            this.snake = new Queue<Point>();

            for (int i = 1; i < 6; i++)
            {
                Point snakeBody = new Point(i, 17);
                snake.Enqueue(snakeBody);
                snakeBody.Draw(SnakeBodySymbol);
            }

            Point snakeHead = new Point(6, 17);
            snake.Enqueue(snakeHead);
            Console.BackgroundColor = ConsoleColor.White;
            snakeHead.Draw('=');
            Console.BackgroundColor = ConsoleColor.Black;

            this.foodIndex = GetRandomIndex();

            this.foods[this.foodIndex].PlaceOnARandomPosition(this, this.snake, this.Bricks);
        }

        private void PrintInfo()
        {
            if (this.Points > this.neededPoints)
            {
                this.neededPoints += 10;

                this.Level = (this.Points / 10 + 1);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(140, 17);
            Console.WriteLine($"Points: {this.Points}");
            Console.SetCursorPosition(140, 18);
            Console.WriteLine($"Level: {this.Level}");
        }
    }
}
