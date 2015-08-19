using ModelingObjectTask.Items;
using System;

namespace ModelingObjectTask.BodyParts
{
    public class Head : BodyPart
    {
        public override void PutOn(Item item)
        {
            Type t = item.GetType();
            if (t == typeof(Helmet))
            {
                Clothes = (Clothes)item;
            }
            else if (t == typeof(Weapon))
            {
                Item = item;
            } 
        }
    }
}
