namespace Simulator.Maps
{
    /// <summary>
    /// Map of points.
    /// </summary>
    public abstract class Map
    {
        public int SizeX {get; private init; }
        public int SizeY { get; private init; }
        protected Rectangle MapSquare {get; private init; }
        public Dictionary<IMappable, Point> Creatures { get; set; }
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
                Creatures = new Dictionary<IMappable, Point>();
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

        public bool AddCreature(IMappable c, Point p)
        {
            if (this.Exist(p) && !Creatures.ContainsKey(c))
            {
                Creatures[c] = p;
                return true;
            }
            else
                return false;
        }
        public void Remove(IMappable c)
        {
                Creatures.Remove(c);
                c.RemoveMap();
        }
        public void Move(IMappable c, Point p)
        {
            if (Creatures.ContainsKey(c))
            {
                Creatures[c] = p;
            }
        }
        public List<IMappable> At(Point p) => this.At(p.X, p.Y);
        public List<IMappable> At(int x, int y)
        {
            Point p = new(x, y);
            return Creatures.Where(kvp => kvp.Value.Equals(p)).Select(kvp => kvp.Key).ToList();
        }


    }
}
