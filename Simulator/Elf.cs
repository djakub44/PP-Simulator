﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Elf : Creature
    {
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
            Console.WriteLine($"{Name} is singing.");
            singCounter = Validate.Counter(singCounter, 3);
            if (singCounter == 0)
                agility = Validate.Limit(agility + 1, 0, 10);
        }
        public override int Power => (8 * Level) + (2 * Agility);
        public override void SayHi() => Console.WriteLine($"Hi Im {Name} and my level is {Level} and my agility is {Agility}");
        public override string Info => $"{Name} [{Level}][{Agility}]";
    }
}