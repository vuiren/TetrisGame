using TetrisGame.UpdateSystems;

namespace TetrisGame
{
    internal class Game
    {
        public static int MoveFiguresDownEveryFramesCount = 30;

        private readonly IUpdateSystem[] updateSystems;
        private readonly GameState state;

        public Game()
        {
            var settings = new FieldSettings(15, 12);
            var field = new Field(settings);

            updateSystems = new IUpdateSystem[]
            {
                new ReadInput(),
                new MarkCellsToRedraw(),

                new AddShapeWhenNoMovingFiguresLeft(),

                new ForceMoveDown(),
                new MoveFiguresByInput(),
                new FreezeMovingFiguresUponReachingFieldBottom(),
                new FreezeMovingFiguresOnCollision(),
                new FreezeFigureCells(),
                new MoveMovingFiguresDown(),

                new DeleteFrozenFigures(),

                new ClearFilledRow(),
                new ClearField(),
                new PlaceFieldCellsOnField(),
            };

            state = new GameState(field);
        }

        public void Run()
        {
            DrawField(state);
            DrawAt(state.field.fieldSettings.Width + 10, 0, "Управление: стрелки влево/вправо/вниз");

            while (!state.gameOver)
            {
                state.currentFrame++;

                Update(updateSystems, state);
                Draw(state);

                DrawAt(state.field.fieldSettings.Width + 10, 1, "Счёт: " + state.score);

                DrawAt(new Vector2Int(0, state.field.fieldSettings.Height + 1), "Текущий кадр: " + state.currentFrame.ToString());
                DrawAt(new Vector2Int(0, state.field.fieldSettings.Height + 2), "Жду кадр: " + state.nextMovingFiguresDownFrame.ToString());

                Thread.Sleep(10);
            }

            DrawAt(new Vector2Int(0, state.field.fieldSettings.Height + 2), "Проигрыш");
        }

        private static void Draw(GameState state)
        {
            var field = state.field;

            foreach (var e in state.cellsToRedraw)
            {
                Console.SetCursorPosition(e.x, e.y);
                Console.Write(" ");
            }

            for (int y = 0; y < field.fieldSettings.Height; y++)
            {
                for (int x = 0; x < field.fieldSettings.Width; x++)
                {
                    if (field.field[x, y])
                    {
                        DrawAt(new Vector2Int(x, y), "X");
                    }
                }
            }
        }

        private static void DrawAt(Vector2Int position, string text)
        {
            DrawAt(position.x, position.y, text);
        }

        private static void DrawAt(int x, int y, string text)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }

        private static void DrawField(GameState state)
        {
            var field = state.field;
            for (int y = 0; y < field.fieldSettings.Height; y++)
            {
                for (int x = 0; x < field.fieldSettings.Width; x++)
                {
                    if (x == 0)
                    {
                        Console.Write("|");
                    }

                    Console.Write(" ");

                    if (x == field.fieldSettings.Width - 1)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void Update(IUpdateSystem[] updateSystems, GameState state)
        {
            foreach (var e in updateSystems)
            {
                e.Update(state);
            }
        }
    }
}
