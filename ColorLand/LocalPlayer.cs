using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace ColorLand
{
    public class LocalPlayer : Player
    {
        public LocalPlayer(string name, int index, Rectangle brush)
            : base(name, index, brush)
        {
        }
    }
}
