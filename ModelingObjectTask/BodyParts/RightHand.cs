using ModelingObjectTask.Items;
using System;

namespace ModelingObjectTask.BodyParts
{
    public class RightHand:BodyPart
    {


        public RightHand(int health)
        {
            weapon = new Weapon();
            Health = health;
        }

        public override void PutOn(Items.Item item)
        {
            Item = item;
            if (item.GetType() == typeof(Weapon))
            {
                Weapon = (Weapon)item;
            }
        }
    }
}
