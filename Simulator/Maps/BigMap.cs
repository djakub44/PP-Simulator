using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public abstract class BigMap(int sizeX, int sizeY) : Map(sizeX, sizeY, 1000, 1000)
    {
    }
}
