using ModelingObjectTask.Items;
using System;

namespace ModelingObjectTask.BodyParts
{
    class Body:BodyPart
    {

        public override void PutOn(Item item)
        {
            if(item.GetType() == typeof (Armour))
            {
                this.Item = item;
            }
        }
    }
}
