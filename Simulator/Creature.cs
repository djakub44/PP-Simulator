using System;
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
    class Creature
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

        //public properties & methods
        public string Info => $"{Name} [{Level}]";
        public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }
    public static class Validate
    {
        public static int Limit(int number, int min, int max)
        {
            if (number < min)
                number = min;
            else if (number > max)
                number = max;
            return number;
        }
        public static string Limit(string name, int min, int max)
        {
            name = name.Trim().Length >= max ? name.Trim().Substring(0, max).Trim() : name.Trim();
            name = name.Length >= min ? name : FillName(name);
            name = char.IsAsciiLetterLower(name[0]) ? name[0].ToString().ToUpper() + name.Substring(1, name.Length - 1) : name;
            return name;
        }
        static private string FillName(string name)
        {
            while (name.Length < 3)
            {
                name = name + "#";
            }
            return name;
        }
    }
}
