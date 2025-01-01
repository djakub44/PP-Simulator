using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {
        public SmallMap(int size) : base(size, 20) { }
    }
}
