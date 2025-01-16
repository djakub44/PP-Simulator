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
        void SetMap(Map map, Point location)
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
            if (Map is not null && Map.CreatureExistsOnMap(this))
            {
                Map.Creatures[Location].Remove(this);
                Map = null;
                Location = default;
            }
        }
        void Go(Direction direction);
        
    }
}
