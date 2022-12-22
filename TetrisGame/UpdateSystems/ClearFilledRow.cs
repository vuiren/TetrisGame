using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame.UpdateSystems
{
    internal class ClearFilledRow : IUpdateSystem
    {
        public void Update(GameState state)
        {
            var field = state.field;

            for (int y = 0; y < field.fieldSettings.Height; y++)
            {
                var cellsOnRow = state.allCells.Where(x => x.y == y && !x.moving).ToList();

                if (cellsOnRow.Count == field.fieldSettings.Width - 1)
                {
                    state.cellsToRedraw.AddRange(cellsOnRow.Select(x => new Vector2Int(x.x, x.y)));
                    state.allCells.RemoveAll(x => x.y == y && !x.moving);

                    MoveAllFrozenCellsDown(state, y);
                    state.score += 10;
                }
            }
        }

        private void MoveAllFrozenCellsDown(GameState state, int startY)
        {
            for (int y = startY - 1; y > 0; y--)
            {
                var cells = state.allCells.Where(x => x.y == y && !x.moving);

                foreach (var cell in cells)
                {
                    cell.y++;
                    state.cellsToRedraw.Add(new Vector2Int(cell.x, cell.y));
                }
            }
        }
    }
}
