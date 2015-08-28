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
        

        public Weapons()
        {
            Attack = 1;
           
        }
    }
}
