namespace TetrisGame.UpdateSystems
{
    internal class AddShapeWhenNoMovingFiguresLeft : IUpdateSystem
    {
        private int[,] shape1 = new int[,]
        {
            { 1, 1, 0 },
            { 0, 1, 1 },
        };

        private int[,] shape2 = new int[,]
        {
            { 1, 1, 0 },
            { 1, 1, 0 },
        };

        private int[,] shape3 = new int[,]
        {
            { 1, 1, 1},
        };

        private int[,] shape4 = new int[,]
        {
            {1},
            {1},
            {1},
            {1},
        };

        private readonly List<int[,]> shapes;

        public AddShapeWhenNoMovingFiguresLeft()
        {
            shapes = new List<int[,]>
            {
                shape1,
                shape2,
                shape3,
                shape4
            };

        }

        public void Update(GameState state)
        {
            if (state.figures.Any(figure => figure.moving))
            {
                return;
            }

            var random = new Random();
            var width = state.field.fieldSettings.Width - 1;

            var shape = shapes[random.Next(0, shapes.Count)];

            var newFigure = GetFigureFromShape(random.Next(1, width - shape.GetLength(0)), 0, shape);
            state.figures.Add(newFigure);

            foreach (var cell in newFigure.figureCells)
            {
                if (state.allCells.Any(x => x.x == cell.x && x.y == cell.y && !x.moving))
                {
                    state.gameOver = true;
                }
            }

            state.allCells.AddRange(newFigure.figureCells);
        }

        private static Figure GetFigureFromShape(int x, int y, int[,] shape)
        {
            var figureCells = new List<FigureCell>();

            for (int i = 0; i < shape.GetLength(0); i++)
            {
                for (int j = 0; j < shape.GetLength(1); j++)
                {
                    if (shape[i, j] == 1)
                    {
                        figureCells.Add(new FigureCell(x + j, y + i));
                    }
                }
            }

            return new Figure(figureCells.ToArray());
        }
    }
}
