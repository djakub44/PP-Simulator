using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;

namespace Simulator.Maps
{
    /// <summary>
    /// Map of points.
    /// </summary>
    public abstract class Map
    {
        public int SizeX { get; private init; }
        public int SizeY { get; private init; }
        protected Rectangle MapSquare { get; private init; }
        public Dictionary<Point, List<IMappable>> Creatures { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param sizeX>Size X of the map.</param>
        /// <param sizey>Size Y of the map.</param>
        /// <param maxX>maximum X size of the map.</param>
        /// <param maxY>maximum Y size of the map.</param>
        /// <returns></returns>
        public Map(int sizeX, int sizeY, int maxX, int maxY)
        {
            if (Validate.LimitSize(sizeX, 5, maxX) && Validate.LimitSize(sizeY, 5, maxY))
            {
                SizeX = sizeX;
                SizeY = sizeY;
                MapSquare = new Rectangle(0, 0, sizeX - 1, sizeY - 1);
                Creatures = new Dictionary<Point, List<IMappable>>();
            }
            else
                throw new ArgumentOutOfRangeException($"Size X of Small Map must be between 5 and {maxX}. Size Y of Small Map must be between 5 and {maxY}");
        }

        /// <summary>
        /// Check if given point belongs to the map.
        /// </summary>
        /// <param name="p">Point to check.</param>
        /// <returns></returns>
        public bool Exist(Point p) => MapSquare.Contains(p);

        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point Next(Point p, Direction d);

        /// <summary>s
        /// Next diagonal position to the point in a given direction 
        /// rotated 45 degrees clockwise.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point NextDiagonal(Point p, Direction d);

        public bool CreatureExistsOnMap(IMappable c)
        {
            foreach (Point p in Creatures.Keys)
            {
                foreach (IMappable i in Creatures[p])
                {
                    if (i == c)
                        return true;
                }
            }
            return false;
        }

        public bool AddCreature(IMappable c, Point p, bool initial = true)
        {
            if (this.Exist(p))
            {
                if (!Creatures.ContainsKey(p))
                    Creatures[p] = new List<IMappable>();
                if (Creatures[p].Contains(c) && initial)
                    return false;
                else
                {
                    Creatures[p].Add(c);
                    return true;
                }
            }
            else
                return false;
        }
        public void Remove(IMappable c)
        {
            c.RemoveMap();
        }
        public void Move(IMappable c, Point p, Point nextP)
        {
            Creatures[p].Remove(c);
            AddCreature(c, nextP, false);
        }
        public List<IMappable> At(Point p) => this.At(p.X, p.Y);
        public List<IMappable> At(int x, int y)
        {
            //Point p = new(x, y);
            //return Creatures.Where(kvp => kvp.Value[p].Equals(p)).Select(kvp => kvp.Key).ToList();

            Point p = new(x, y);
            if (Creatures.ContainsKey(p))
            {
                return Creatures[new Point(x, y)];
            }
            else
                return new List<IMappable>();

        }
    }
}
