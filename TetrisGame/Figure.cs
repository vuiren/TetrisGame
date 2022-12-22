namespace TetrisGame
{
    internal class Figure
    {
        public FigureCell[] figureCells;

        public bool moving;

        public Figure(FigureCell[] figureCells)
        {
            this.figureCells = figureCells;
            moving = true;
        }

        internal void MoveLeft()
        {
            foreach(var cell in figureCells)
            {
                cell.x--;
            }
        }

        internal void MoveRight()
        {
            foreach (var cell in figureCells)
            {
                cell.x++;
            }
        }

        internal FigureCell RightMostCell()
        {
            return figureCells.OrderByDescending(x => x.x).First();
        }

        internal FigureCell LeftMostCell()
        {
            return figureCells.OrderBy(x => x.x).First();
        }
    }
}
