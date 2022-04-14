namespace SnakeGame.GameObjects
{
    public class SpecialFood : Food
    {
        private const char FoodSymbol = '\u25A0';
        private const int FoodPoints = 3;

        public SpecialFood(Wall wall) 
            : base(wall, FoodSymbol, FoodPoints)
        {
        }
    }
}
