using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Orc : Creature
    {
        public override char Symbol { get; } = 'O';
        public Orc(string name, SmallMap map, Point location, int level = 1, int rage = 0) : base(name, map, location)
        {
            Rage = rage;
        }
        public Orc(string name, int level = 1, int rage = 0) : base(name, level)
        {
            Rage = rage;
        }
        public Orc() : base() { }
        private int rage = 1;
        public int Rage { get=>rage; 
            init
            {
                rage = Validate.Limit(value, 0, 10);
            } }
        private int huntCounter = 0;
        public void Hunt()
        {
            huntCounter = Validate.Counter(huntCounter, 2);
            if (huntCounter == 0)
                rage = Validate.Limit(rage + 1, 0, 10);
        }
        public override int Power => (7*Level)+(3*Rage);
        public override string Greeting() => $"Hi Im {Name} and my level is {Level} and my rage is {Rage}";
        public override string Info => $"{Name} [{Level}][{Rage}]";
        
    }
}
