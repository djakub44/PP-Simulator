using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    class Creature
    {

        public string? Name { get; set; }
        public int Level { get; set; } = 1;
        public Creature(string name)
        {
            Name = name;
        }
        public Creature() { }
        public string Info => $"{Name} [{Level}]";
        public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
        

    }
}
