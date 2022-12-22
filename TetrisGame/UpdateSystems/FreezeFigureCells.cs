using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame.UpdateSystems
{
    internal class FreezeFigureCells : IUpdateSystem
    {
        public void Update(GameState state)
        {
            foreach (var figure in state.figures)
            {
                if (figure.moving) continue;
                
                foreach (var cell in figure.figureCells)
                {
                    cell.moving = false;
                }
            }
        }
    }
}
