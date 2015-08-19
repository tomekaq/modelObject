using ModelingObjectTask.Items;
using System;

namespace ModelingObjectTask.BodyParts
{
    public class Body : BodyPart
    {

        public override void PutOn(Item item)
        {
            Type t = item.GetType();
            if (t == typeof(Clothes))
            {
                Clothes = (Clothes)item;
            }
        }
    }
}
