namespace TetrisGame.UpdateSystems
{
    internal class MoveMovingFiguresDown : IUpdateSystem
    {
        public void Update(GameState state)
        {
            if (state.currentFrame < state.nextMovingFiguresDownFrame) return;
            
            foreach (var figure in state.figures)
            {
                foreach (var cell in figure.figureCells)
                {
                    if (cell.moving)
                    {
                        cell.y++;
                    }
                }
            }

            state.nextMovingFiguresDownFrame += Game.MoveFiguresDownEveryFramesCount;
        }
    }
}
