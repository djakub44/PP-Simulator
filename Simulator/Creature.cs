﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    public abstract class Creature
    {
        private int level;
        private string name = "Unknown";
        public string Name
        {
            get => name;
            init
            {
                name = Validate.Limit(value, 3, 25);
            }
        }
        public abstract string Info { get; }
        public int Level
        {
            get => level;
            init
            {
                level = Validate.Limit(value, 1, 10);
            }
        }
        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }
        public Creature() { }

        public void Upgrade()
        {
            if (level < 10)
                level++;
        }
        public abstract void SayHi();
        public abstract int Power { get; }
        public void Go(Direction direction) => Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}");
        public void Go(Direction[] directions)
        {
            foreach (var direction in directions)
            {
                Go(direction);
            }   
        }
        public void Go(string directions) => Go(DirectionParser.Parse(directions));
        public override string ToString() => string.Concat(this.GetType().Name,": ", Info);
    }
}
