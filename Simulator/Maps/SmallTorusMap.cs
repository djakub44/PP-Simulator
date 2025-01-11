using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallTorusMap : SmallMap
    {
        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }
        public override Point Next(Point p, Direction d)
        {
            if (MapSquare.Contains(p.Next(d)))
                return p.Next(d);
            else
                return p.Next(d, SizeX, SizeY);
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            if (MapSquare.Contains(p.NextDiagonal(d)))
                return p.NextDiagonal(d);

            else if (MapSquare.Contains(p.Next(d).Next(d + 1, SizeX, SizeY)))
                return p.Next(d).Next(d +1, SizeX, SizeY);

            else if (MapSquare.Contains(p.Next(d, SizeX, SizeY).Next(d + 1)))
                return p.Next(d, SizeX, SizeY).Next(d+1);

            else
                return p.Next(d, SizeX, SizeY).Next(d +1, SizeX, SizeY);
        }   
    }
}
