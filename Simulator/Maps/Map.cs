namespace Simulator.Maps
{
    /// <summary>
    /// Map of points.
    /// </summary>
    public abstract class Map
    {
        public int Size {get; private init; }
        protected Rectangle MapSquare {get; private init; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param size>Size of the map.</param>
        /// <param max>maximum size of the map.</param>
        /// <returns></returns>
        public Map(int size, int max)
        {
            if (Validate.LimitSize(size, 5, max))
            {
                Size = size;
                MapSquare = new Rectangle(0, 0, size - 1, size - 1);
            }
            else
                throw new ArgumentOutOfRangeException($"Size of Small Map must be between 5 and {max}");
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
    }
}
