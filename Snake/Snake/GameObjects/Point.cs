using System;

namespace SnakeGame.GameObjects
{
    public class Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Draw(char symbol) 
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(symbol);
        }

        public void Draw(int x, int y, char symbol) 
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(symbol);
        }
    }
}
