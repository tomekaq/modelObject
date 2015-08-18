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
