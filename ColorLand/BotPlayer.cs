using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace ColorLand
{
    class BotPlayer : Player
    {
        public BotPlayer(string name, int index, Rectangle brush)
            : base(name, index, brush)
        {
        }
    }
}
