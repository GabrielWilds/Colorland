using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorLand
{
    public class Card
    {
        public GameColors Color
        {
            get;
            private set;
        }

        public Card(GameColors _color)
        {
            Color = _color;
        }
    }
}
