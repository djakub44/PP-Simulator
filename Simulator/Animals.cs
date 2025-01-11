using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Animals : IMappable
    {
        public virtual char Symbol { get; init; } = 'A';
        private string description = "Unknown";
        //private uint size;
        public required string Description 
        {
            get => description;
            init
            {
                description = Validate.Limit(value, 3, 15);
            }
        }
        public uint Size { get; set; } = 3;


        public virtual string Info => $"{Description} <{Size}>";

        public Map? Map { get; set; }
        public Point Location { get; set; }

        public Animals() { }
        public Animals(Map map, Point location)
        {
            if (map.AddCreature(this, location))
            {
                Map = map;
                Location = location;
            }
        }
        public override string ToString() => string.Concat(this.GetType().Name, ": ", Info);



    }

}
