using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Birds : Animals
    {
        public bool CanFly { get; init; } = true;
        public override char Symbol { get 
            {
                if (CanFly)
                    return 'B';
                else
                    return 'b';
            } 
        }
        public Birds() : base()
        {
            
        }
        public override string Info
        {
            get
            {
                return string.Concat($"{Description} ", (CanFly == true) ? "(Fly+)" : "(Fly-)",$" <{Size}>");
            }
        }
        public void Go(Direction direction)
        {
            if (Map is not null)
            {
                if (CanFly)
                {
                    Location = Map.Next(Location, direction);
                    Location = Map.Next(Location, direction);
                    Map.Move(this, Location);
                }
                else
                {
                    Location = Map.NextDiagonal(Location, direction);
                    Map.Move(this, Location);
                }
            }
            else
                throw new Exception("Creature is not on the map");
        }
    }
}
