using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public static class DirectionParser
    {
        public static Direction[] Parse(string input)
        {
            string tempresult = "";
            Dictionary<char, Direction> dictDirections = new Dictionary<char, Direction>()
            {
                { 'U', Direction.Up },
                { 'D', Direction.Down },
                { 'L', Direction.Left},
                { 'R', Direction.Right }
            };
            foreach (var c in input.ToUpper())
            {
                if (dictDirections.Keys.Contains(c))
                    tempresult += c;
            }
            Direction[] result = new Direction[tempresult.Length];
            for (int i = 0; i < tempresult.Length; i++)
            {
                result[i] = dictDirections[tempresult[i]];
            }
            return result;
        }
    }
}

