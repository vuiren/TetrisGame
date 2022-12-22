namespace TetrisGame
{
    internal struct Vector2Int
    {
        public int x, y;

        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    
    internal class GameState
    {
         
        public Field field;
        public List<Figure> figures = new();
        public List<FigureCell> allCells = new();
        public List<Vector2Int> cellsToRedraw = new();

        public int currentFrame;
        public float deltaTime;
        public int nextMovingFiguresDownFrame = 30;

        public int score = 0;
        
        public bool leftKeyPressed, rightKeyPressed, downKeyPressed;
        public bool gameOver;


        public GameState(Field field)
        {
            this.field = field;
        }
    }
}
