using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace ColorLand
{
    public class Player
    {
        public int PlayerID
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public int Position
        {
            get;
            set;
        }

        public string CurPlayer
        {
            get;
            set;
        }

        public Rectangle Sprite
        {
            get;
            set;
        }

        public Player(string _name, int index, Rectangle brush)
        {
            Name = _name;
            PlayerID = index;
            Sprite = brush;
        }

        
    }
}
