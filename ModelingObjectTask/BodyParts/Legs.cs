using ModelingObjectTask.Items;
using System;

namespace ModelingObjectTask.BodyParts
{
    public class Legs:BodyPart
    {

        public override void PutOn(Item przedmiot)
        {
            Item = item;
            if (item.GetType() == typeof(Trousers))
            {
                //clothes = (Clothes)item;
            }
        }
    }
}
