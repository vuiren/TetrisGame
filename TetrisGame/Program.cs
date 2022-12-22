namespace TetrisGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                
                var game = new Game();
                game.Run();

                Console.WriteLine("\nPress any key to restart");
                Console.ReadKey();
            }
        }
    }
}