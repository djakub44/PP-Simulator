using Simulator.Maps;
using System.Data.Common;

namespace Simulator
{
    public abstract class Creature
    {
        private int level;
        private string name = "Unknown";
        public abstract int Power { get; }
        public string Name
        {
            get => name;
            init
            {
                name = Validate.Limit(value, 3, 25);
            }
        }
        public abstract string Info { get; }
        public int Level
        {
            get => level;
            init
            {
                level = Validate.Limit(value, 1, 10);
            }
        }
        public SmallMap? Map { get; private set; }
        public Point Location { get; private set; }
        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }
        public Creature(string name, SmallMap map, Point location, int level = 1) : this(name, level)
        {
            if (map.AddCreature(this,location))
            {
                Map = map;
                Location = Location;
            }
        }
        public Creature() { }
        public void Upgrade()
        {
            if (level < 10)
                level++;
        }
        //maps services and movement
        public void SetMap(SmallMap map, Point location)
        {
            if (Validate.MapNull(this) && map.AddCreature(this, location))
            {
                Map = map;
                Location = location;
            }
            else
                throw new Exception("Cannot change map");
        }
        public void RemoveMap()
        {
            if (Map is not null)
            {
                if (Map.Creatures.ContainsKey(this))
                {
                    Map.Creatures.Remove(this);
                }
                Map = null;
                Location = default;
            }
        }
        public void Go(Direction direction)
        {
            if (Map is not null)
            {
                Location = Map.Next(Location, direction);
                Map.Move(this, Location);

            }
            else
                throw new Exception("Creature is not on the map");  
        }

        //public string[] Go(Direction[] directions) => directions.Select(direction => Go(direction)).ToArray();
        //public string[] Go(string directions) => Go(DirectionParser.Parse(directions));
        //other methods
        public override string ToString() => string.Concat(this.GetType().Name, ": ", Info);
        public abstract string Greeting();
        public void PrintStatus()
        {
            if (Map is not null)
            {
                Console.WriteLine($"Name: {Name} Map: {Map.Size} Location: {Location}");
            }
            else
            {
                Console.WriteLine($"Name: {Name} Map: Null Location: {Location}");
            }
        }

    }
}
