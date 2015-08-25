using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingObjectTask.Items
{
    public abstract class Weapons : Item
    {
        public virtual int Attack { get; set; }
        public virtual int Defense { get; set; }

        public Weapons()
        {
            Attack = 1;
            Defense = 1;
        }
    }
}
