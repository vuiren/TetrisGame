namespace TetrisGame.UpdateSystems
{
    internal class FreezeMovingFiguresUponReachingFieldBottom : IUpdateSystem
    {
        public void Update(GameState state)
        {
            foreach(var figure in state.figures)
            {
                if (!figure.moving) continue;
                
                foreach (var cell in figure.figureCells)
                {
                    if (cell.moving)
                    {
                        if (cell.y == state.field.fieldSettings.Height - 1)
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
