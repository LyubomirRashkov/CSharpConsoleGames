namespace SnakeGame.GameObjects
{
    public class SimpleFood : Food
    {
        private const char FoodSymbol = ' ';
        private const int FoodPoints = 1;

        public SimpleFood(Wall wall) 
            : base(wall, FoodSymbol, FoodPoints)
        {
        }
    }
}
