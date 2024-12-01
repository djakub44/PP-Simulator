using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Animals
    {
        private string description = "Unknown";
        //private uint size;
        public required string Description 
        {
            get => description;
            init
            {
                description = Validate.Limit(value, 3, 15);
            }
        }
        public uint Size { get; set; } = 3;


        public virtual string Info => $"{Description} <{Size}>";

        public Animals()
        {
            
        }
        public override string ToString() => string.Concat(this.GetType().Name, ": ", Info);



    }

}
