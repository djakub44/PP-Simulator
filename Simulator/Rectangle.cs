using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Rectangle
    {
        //X1, Y1 - bottom left, X2, Y2 - upper right
        private readonly int X1, Y1, X2, Y2;

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            if (Validate.Collinear(new Point(x1, y1), new Point(x2, y2)))
                throw new ArgumentException("Points cannot be collinear");

            //make sure corners are assigned to the correct fields
            if (x1 < x2)
                (X1, Y1, X2, Y2) = (x1, y1, x2, y2);
            else
                (X1, Y1, X2, Y2) = (x2, y2, x1, y1);
        }

        public Rectangle(Point p1,Point p2) : this(p1.X, p1.Y, p2.X, p2.Y) { }
        
        public bool Contains(Point p)
        {
            if (p.X >= X1 && p.X <= X2 && p.Y >= Y1 && p.Y <= Y2) 
                return true;
            else
                return false;
        }
        public bool Contains(int x1, int y1)
        {
            return Contains(new Point(x1,y1));
        }
        public override string ToString()
        {
            return $"({X1}, {Y1}):({X2}, {Y2})";
        }
    }
}