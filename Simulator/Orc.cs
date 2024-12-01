using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Orc : Creature
    {
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
            Console.WriteLine($"{Name} is hunting.");
            huntCounter = Validate.Counter(huntCounter, 2);
            if (huntCounter == 0)
                rage = Validate.Limit(rage + 1, 0, 10);
        }
        public override int Power => (7*Level)+(3*Rage);
        public override void SayHi() => Console.WriteLine($"Hi Im {Name} and my level is {Level} and my rage is {Rage}");
        public override string Info => $"{Name} [{Level}][{Rage}]";
        
    }
}
