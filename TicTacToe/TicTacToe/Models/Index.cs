namespace TicTacToe.Models
{
    public class Index
    {
        public Index(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public Index(int[] index)
        {
            this.Row = index[0];
            this.Col = index[1];
        }

        public int Row { get; private set; }

        public int Col { get; private set; }

        public override bool Equals(object obj)
        {
            Index otherIndex = obj as Index;

            return this.Row == otherIndex.Row && this.Col == otherIndex.Col;
        }
    }
}
