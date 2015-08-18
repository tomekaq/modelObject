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

        public override void PutOn(Item item)
        {
                Item = item;
                if (item.GetType() == typeof(Weapon))
                {
                    Weapon = (Weapon)item;
                }
        }
        public Weapon Weapon
        {
            get
            {
                return weapon;
            }
            set
            {
                weapon = value;
            }
        }
    }

}
