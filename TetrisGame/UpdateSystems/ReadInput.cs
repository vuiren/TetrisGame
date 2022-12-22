using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame.UpdateSystems
{
    internal class ReadInput : IUpdateSystem
    {
        public void Update(GameState state)
        {
            state.leftKeyPressed = false;
            state.rightKeyPressed = false;
            state.downKeyPressed = false;
            
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        state.leftKeyPressed = true;
                        break;
                    case ConsoleKey.RightArrow:
                        state.rightKeyPressed = true;
                        break;
                    case ConsoleKey.DownArrow:
                        state.downKeyPressed = true;
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
