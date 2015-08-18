using ModelingObjectTask.Items;
using System;

namespace ModelingObjectTask.BodyParts
{
    public class Head : BodyPart
    {
        public override void PutOn(Item item)
        {
            Item = item;
            if (item.GetType() == typeof(Helmet))
            {
                Clothes = (Clothes)item;
            }
        }
    }
}
