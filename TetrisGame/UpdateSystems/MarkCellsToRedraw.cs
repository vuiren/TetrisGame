namespace TetrisGame.UpdateSystems
{
    internal class MarkCellsToRedraw : IUpdateSystem
    {
        public void Update(GameState state)
        {
            state.cellsToRedraw = new List<Vector2Int>();

            foreach (var figure in state.figures)
            {
                foreach (var cell in figure.figureCells)
                {
                    if (!cell.moving) continue;

                    state.cellsToRedraw.Add(new Vector2Int(cell.x, cell.y));
                }
            }
        }
    }
}
