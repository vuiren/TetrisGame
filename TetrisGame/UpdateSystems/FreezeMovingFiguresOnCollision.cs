namespace TetrisGame.UpdateSystems
{
    internal class FreezeMovingFiguresOnCollision : IUpdateSystem
    {
        public void Update(GameState state)
        {
            foreach (var figure in state.figures)
            {
                if (!figure.moving) continue;
                
                foreach (var cell in figure.figureCells.OrderByDescending(x => x.y))
                {
                    if (cell.moving)
                    {
                        var cellBelow = state.allCells.FirstOrDefault(c => c.x == cell.x && c.y == cell.y + 1);
                        if (cellBelow == null)
                            continue;

                        if (state.field.field[cell.x, cell.y + 1] && !cellBelow.moving)
                        {
                            figure.moving = false;
                            break;
                        }
                    }
                }
            }
        }
    }
}
