using ModelingObjectTask.Items;
using System;

namespace ModelingObjectTask.BodyParts
{
    public class Legs:BodyPart
    {

        public override void PutOn(Item item1)
        {
            if (item1.GetType() == typeof(Trousers))
            {
                Item = item;
                Clothes = (Clothes)item;
            }
        }
    }
}
//17.17