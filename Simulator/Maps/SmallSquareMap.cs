using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallSquareMap : Map
    {
        public int Size { get; init; }
        private Rectangle MapSquare { get; init; }
        public SmallSquareMap(int size)
        {
            if (Validate.LimitSize(size, 5, 20))
            {
                Size = size;
                MapSquare = new Rectangle(0, 0, size - 1, size - 1);
            }
            else
                throw new ArgumentException("Size of Small Map must be between 5 and 20");
        }
        public override bool Exist(Point p) => MapSquare.Contains(p);

        public override Point Next(Point p, Direction d)
        {
            if (MapSquare.Contains(p.Next(d)))
                return p.Next(d);
            else
                return p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            if (MapSquare.Contains(p.NextDiagonal(d)))
                return p.NextDiagonal(d);
            else
                return p;
        }
    }
}
