using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
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
        public static int Counter(int number,int max)
        {
            if (number < max)
                return ++number;
            else
                return 0;
        }
    }
}
