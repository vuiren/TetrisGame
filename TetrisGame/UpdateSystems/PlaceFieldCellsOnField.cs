namespace TetrisGame.UpdateSystems
{
    internal class PlaceFieldCellsOnField : IUpdateSystem
    {
        public void Update(GameState state)
        {
            foreach (var cell in state.allCells)
            {
                state.field.field[cell.x, cell.y] = true;
            }

        }
    }
}
