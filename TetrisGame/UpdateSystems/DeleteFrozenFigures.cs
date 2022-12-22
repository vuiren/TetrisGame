namespace TetrisGame.UpdateSystems
{
    internal class DeleteFrozenFigures : IUpdateSystem
    {
        public void Update(GameState state)
        {
            state.figures = state.figures.Where(x => x.moving).ToList();
        }
    }
}
