using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    internal class Creature
    {
        public string? Name
        {
            get { return Name; }
        }

        private int level;
        public int Level
        {
            get { return level; }
            set { level = value > 0 ? value : 1; }
        }
        
    }
}
