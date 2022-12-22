namespace TetrisGame
{
    internal class FigureCell
    {
        public int x, y;
        public bool moving = true;

        public FigureCell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
