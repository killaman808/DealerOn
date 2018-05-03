using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverDealerOn
{
    public class Grid : IGrid
    {
        public int maxX { get; set; }
        public int maxY { get; set; }

        public Grid(Point P)
        {
            maxX = P.X;
            maxY = P.Y;
        }
    }
}
