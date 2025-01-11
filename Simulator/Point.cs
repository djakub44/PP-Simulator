using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public readonly struct Point
    {
        public readonly int X, Y;
        public Point(int x, int y) => (X, Y) = (x, y);
        public override string ToString() => $"{X}, {Y}";

        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        /// <param name="direction">Direction.</param>
        /// /// <param name="size">Size of the map. If provided, function will return point on the other side of the torus map. True size should be provided - If the map has size 5 (coordinates starting from 0 to 4) size should be 5</param>
        /// <returns>Next point.</returns>
        public Point Next(Direction direction, int sizeX = 0, int sizeY = 0)
        {
            if (!((sizeX == 0 && sizeY == 0) || (sizeX != 0 && sizeY != 0)))
            {
                throw new ArgumentException("both size have to be provided or left default");
            }

                var d = direction > Direction.Left ? Direction.Up : direction;
            int x = X, y = Y;
            switch (d)
            {
                case Direction.Right:
                    x = x + 1 - sizeX;
                    break;
                case Direction.Left:
                    x = x - 1 + sizeX; 
                    break;
                case Direction.Up:
                    y = y + 1 - sizeY;
                    break;
                case Direction.Down:
                    y = y - 1 + sizeY;
                    break;
            }
            return new Point(x, y);
        }

        //this works only because directions are sorted clockwise in enum definition
        public Point NextDiagonal(Direction direction) => new Point(X, Y).Next(direction).Next(direction+1);

        public bool Equals(Point other)
        {
            if (other.X == X && other.Y == Y)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        //public override bool Equals(object obj)
        //{
        //    return obj is Point && Equals((Point)obj);
        //}
    }
}
