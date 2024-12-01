using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Birds : Animals
    {
        public Birds() : base() { }
        public bool CanFly { get; init; } = true;
        public override string Info
        {
            get
            {
                return string.Concat($"{Description} ", (CanFly == true) ? "(Fly+)" : "(Fly-)",$" <{Size}>");
            }
        }
    }
}
