using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    internal class FieldSettings
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public FieldSettings(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
