﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingObjectTask.Items
{
    class MagicRing : Clothes
    {
        public override void Apply(Hero hero)
        {
            hero.Strength += 1;
            
        }


    }
}
