using ModelingObjectTask.Items;
using System;

namespace ModelingObjectTask.BodyParts
{
    public class RightHand:BodyPart
    {


        public RightHand(int health)
        {
            Health = health;
        }

        public override void ZalozUbior(Item przedmiot)
        {
            this.item = przedmiot;    
        }
    }
}
