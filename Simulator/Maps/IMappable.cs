using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public interface IMappable
    {
        Map? Map { get; set; }
        Point Location { get; set; }
        void SetMap(SmallMap map, Point location) { }
        void RemoveMap() { }
        void Go(Direction direction) { }
    }
}
