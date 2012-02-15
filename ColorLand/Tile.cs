using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace ColorLand
{
    public class Tile
    {
        public int GridX
        {
            get;
            set;
        }

        public int GridY
        {
            get;
            set;
        }

        public GameColors Color
        {
            get;
            set;
        }

        public Rectangle Rectangle
        {
            get;
            set;
        }

        public Tile(int x, int y, GameColors color)
        {
            GridX = x;
            GridY = y;
            Color = color;
        }

        public int RenderX()
        {
            return (int)Canvas.GetTop(Rectangle);
        }

        public int RenderY()
        {
            return (int)Canvas.GetLeft(Rectangle);
        }
    }
}
