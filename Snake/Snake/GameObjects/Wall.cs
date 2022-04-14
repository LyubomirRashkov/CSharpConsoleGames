using System;

namespace SnakeGame.GameObjects
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';

        public Wall(int x, int y) 
            : base(x, y)
        {
            this.DrawWall();
        }

        private void DrawWall()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            this.DrawHorizontalWall(0);
            this.DrawHorizontalWall(this.Y);

            this.DrawVerticalWall(0);
            this.DrawVerticalWall(this.X);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void DrawVerticalWall(int x)
        {
            for (int y = 0; y <= this.Y; y++)
            {
                this.Draw(x, y, WallSymbol);
            }
        }

        private void DrawHorizontalWall(int y)
        {
            for (int x = 0; x <= this.X; x++)
            {
                this.Draw(x, y, WallSymbol);
            }
        }
    }
}
