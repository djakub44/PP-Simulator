using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public readonly struct Point
    {
        public readonly int X, Y;
        public Point(int x, int y) => (X, Y) = (x, y);
        public override string ToString() => $"{X}, {Y}";

        public Point Next(Direction direction)
        {
            int x = X, y = Y;

            switch (direction)
            {
                case Direction.Right:
                    x++;
                    break;
                case Direction.Left:
                    x--; break;
                case Direction.Up:
                    y++; break;
                case Direction.Down:
                    y--; break;
            }
            return new Point(x, y);
        }

        //this only works because directions are sorted clockwise in enum definition
        public Point NextDiagonal(Direction direction) => new Point(X,Y).Next(direction).Next(direction+1);


    }
}
