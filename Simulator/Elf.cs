using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Elf : Creature
    {
        public override char Symbol { get; } = 'E';
        public Elf(string name, SmallMap map, Point location, int level = 1, int agility = 0) : base(name, map, location)
        {
            Agility = agility;
        }
        public Elf(string name, int level = 1, int agility = 0) : base(name, level)
        {
            Agility = agility;
        }
        private int agility = 0;
        public int Agility
        {
            get => agility; 
            init
            {
                agility = Validate.Limit(value, 0, 10);
            }
        }
        private int singCounter = 0;
        public void Sing()
        {
            singCounter = Validate.Counter(singCounter, 3);
            if (singCounter == 0)
                agility = Validate.Limit(agility + 1, 0, 10);
        }
        public override int Power => (8 * Level) + (2 * Agility);
        public override string Greeting() => $"Hi Im {Name} and my level is {Level} and my agility is {Agility}";
        public override string Info => $"{Name} [{Level}][{Agility}]";
    }
}
