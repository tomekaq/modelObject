using ModelingObjectTask.Items;
using System;

namespace ModelingObjectTask.BodyParts
{
    public class RightHand : BodyPart
    {
        public RightHand()
        {
            health = 1;
        }

        public override void PutOn(Item item)
        {
            Type t = item.GetType();
            if (t == typeof(Shield))
            { 
                Clothes = (Clothes) item; 
            }
            else if (t == typeof(Weapon) || t == typeof(MagicWeapon))
            {
                Item = item;
            }
        }
    }
}
