using ModelingObjectTask.Items;
using System;

namespace ModelingObjectTask.BodyParts
{
    public class RightHand : BodyPart
    {
        public RightHand()
        {

        }

        public override void PutOn(Item item)
        {
            Type t = item.GetType();
            if (t == typeof(Clothes))
            { 
                Clothes = (Clothes) item; 
            }
            else if (t == typeof(Weapon))
            {
                Item = item;
            }
        }
    }
}
