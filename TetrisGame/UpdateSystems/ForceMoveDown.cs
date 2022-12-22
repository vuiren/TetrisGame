namespace TetrisGame.UpdateSystems
{
    internal class ForceMoveDown : IUpdateSystem
    {
        public void Update(GameState state)
        {
            if (!state.downKeyPressed) return;

            state.nextMovingFiguresDownFrame = state.currentFrame + 1;
        }
    }
}
