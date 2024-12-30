using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public int Size { get; init; }
        private Rectangle MapSquare { get; init; }
        public SmallTorusMap(int size)
        {
            if (Validate.LimitSize(size, 5, 20))
            {
                Size = size;
                MapSquare = new Rectangle(0, 0, size - 1, size - 1);
            }
            else
                throw new ArgumentOutOfRangeException("Size of Small Torus Map must be between 5 and 20");
        }

        public override bool Exist(Point p) => MapSquare.Contains(p);

        public override Point Next(Point p, Direction d)
        {
            if (MapSquare.Contains(p.Next(d)))
                return p.Next(d);
            else
                return p.Next(d, Size);
        }



        public override Point NextDiagonal(Point p, Direction d)
        {
            if (MapSquare.Contains(p.NextDiagonal(d)))
                return p.NextDiagonal(d);

            else if (MapSquare.Contains(p.Next(d).Next(d + 1, Size)))
                return p.Next(d).Next(d +1, Size);

            else if (MapSquare.Contains(p.Next(d, Size).Next(d + 1)))
                return p.Next(d, Size).Next(d+1);

            else
                return p.Next(d, Size).Next(d +1,Size);
        }   
    }
}
