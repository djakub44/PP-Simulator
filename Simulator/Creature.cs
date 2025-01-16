using Simulator.Maps;
using System.Data.Common;

namespace Simulator
{
    public abstract class Creature : IMappable
    {
        public virtual char Symbol { get; } = 'C';
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

        public Map? Map { get; set; }
        public Point Location { get; set; }

        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }
        public Creature(string name, Map map, Point location, int level = 1) : this(name, level)
        {
            if (map.AddCreature(this,location))
            {
                Map = map;
                Location = location;
            }
        }
        public Creature() { }
        public void Upgrade()
        {
            if (level < 10)
                level++;
        }
        public void Go(Direction direction)
        {
            if (Map is not null && Map.CreatureExistsOnMap(this) && Map.Creatures.ContainsKey(Location))
            {
                Map.Move(this, Location, Map.Next(Location, direction));
                Location = Map.Next(Location, direction);
            }
            else
                throw new Exception("Creature is not on the map");
        }
        //public string[] Go(Direction[] directions) => directions.Select(direction => Go(direction)).ToArray();
        //public string[] Go(string directions) => Go(DirectionParser.Parse(directions));
        //other methods
        public override string ToString() => string.Concat(this.GetType().Name, ": ", Info);
        public abstract string Greeting();
        //public void PrintStatus()
        //{
        //    if (Map is not null)
        //    {
        //        Console.WriteLine($"Name: {Name} Map: {Map.SizeX} Location: {Location}");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Name: {Name} Map: Null Location: {Location}");
        //    }
        //}

    }
}
