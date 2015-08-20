using ModelingObjectTask.Items;
using System;

namespace ModelingObjectTask.BodyParts
{
    public class Body : BodyPart
    {
        public Body()
        {
            health = 1;
        }

        public override void PutOn(Item item)
        {
            Type t = item.GetType();
            if (t == typeof(Armour))
            {
                Clothes = (Clothes)item;
            }
        }
    }
}
