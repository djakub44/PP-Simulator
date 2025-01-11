using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public interface IMappable
    {
        char Symbol { get; }
        Map? Map { get; set; }
        Point Location { get; set; }
        void SetMap(SmallMap map, Point location)
        {
            if ((Validate.MapNull(this) || this.Map == map) && map.AddCreature(this, location))
            {
                Map = map;
                Location = location;
            }
            else
                throw new Exception("Cannot change map or location out of scope");
        }
        void RemoveMap()
        {
            if (Map is not null)
            {
                Map.Creatures.Remove(this);
                Map = null;
                Location = default;
            }
        }
        void Go(Direction direction)
        {
            if (Map is not null)
            {
                Location = Map.Next(Location, direction);
                Map.Move(this, Location);
            }
            else
                throw new Exception("Creature is not on the map");
        }
    }
}
