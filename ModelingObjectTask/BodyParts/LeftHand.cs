using ModelingObjectTask.Items;
using System;

namespace ModelingObjectTask.BodyParts
{
    public class LeftHand : BodyPart
    {
        public LeftHand()
        {
            weapon = new Weapon();
        }

        public override void ZalozUbior(Items.Item item)
        {
            throw new NotImplementedException();
        }
    }

}
