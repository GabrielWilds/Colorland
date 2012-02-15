using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace ColorLand
{
    class NetPlayer : Player
    {
        public NetPlayer(string name, int index, Rectangle brush)
            : base(name, index, brush)
        { 
        }
    }
}
