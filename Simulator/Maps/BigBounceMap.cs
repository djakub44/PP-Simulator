using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class BigBounceMap : BigMap
    {
        public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }
        public override Point Next(Point p, Direction d)
        {
            if (MapSquare.Contains(p.Next(d)))
                return p.Next(d);
            else if (MapSquare.Contains(p.Next(d + 2)))
                //risky - it only works because directions in enum definition are declared clockwise
                return p.Next(d + 2);
            else
                return p;
        }
        public override Point NextDiagonal(Point p, Direction d)
        {
            if (MapSquare.Contains(p.NextDiagonal(d)))
                return p.NextDiagonal(d);
            else if (MapSquare.Contains(p.NextDiagonal(d + 2)))
                //risky - it only works because directions in enum definition are declared clockwise
                return p.NextDiagonal(d + 2);
            else
                return p;
        }
    }
}
