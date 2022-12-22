namespace TetrisGame.UpdateSystems
{
    internal class MoveFiguresByInput : IUpdateSystem
    {
        public void Update(GameState state)
        {
            if (state.leftKeyPressed)
            {
                foreach(var figure in state.figures)
                {
                    if (!figure.moving) continue;

                    var leftMostCell = figure.LeftMostCell();
                    if (leftMostCell.x == 1) continue;

                    foreach (var cell in figure.figureCells)
                    {
                        if(state.allCells.Any(x=>x.x == cell.x - 1 && x.y == cell.y && !x.moving))
                        {
                            return;
                        }
                    }
                    
                    figure.MoveLeft();
                }
            }
            
            if (state.rightKeyPressed)
            {
                foreach (var figure in state.figures)
                {
                    if (!figure.moving) continue;

                    var rightMostCell = figure.RightMostCell();
                    if (rightMostCell.x == state.field.fieldSettings.Width - 1) continue;                    

                    foreach (var cell in figure.figureCells)
                    {
                        if (state.allCells.Any(x => x.x == cell.x + 1 && x.y == cell.y && !x.moving))
                        {
                            return;
                        }
                    }
                    
                    figure.MoveRight();
                }
            }
        }
    }
}
