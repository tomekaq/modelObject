using ModelingObjectTask.Items;
using System;

namespace ModelingObjectTask.BodyParts
{
    public class Legs:BodyPart
    {
        public Legs()
        {
            health = 1;
        }
        public override void PutOn(Item item)
        {
            Type t = item.GetType();
            if (t == typeof(Trousers))
            {
                Clothes = (Clothes)item;
            }
        }
    }
}
//17.17