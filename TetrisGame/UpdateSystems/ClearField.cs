namespace TetrisGame.UpdateSystems
{
    internal class ClearField : IUpdateSystem
    {
        public void Update(GameState state)
        {
            for (int x = 0; x < state.field.fieldSettings.Width; x++)
            {
                for (int y = 0; y < state.field.fieldSettings.Height; y++)
                {
                    state.field.field[x, y] = false;
                }
            }
        }
    }
}
