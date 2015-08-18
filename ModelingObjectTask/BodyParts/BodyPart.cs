using ModelingObjectTask.Items;

namespace ModelingObjectTask.BodyParts
{
    public abstract class BodyPart
    {
        protected int health;
        protected Item item;
        protected Weapon weapon;
       // protected Ubior ubiór;

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        public Item Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
            }
        }

        public Weapon Weapon
        {
            get
            {
                return weapon;
            }
            set
            {
                weapon = value;
            }
        }

        public abstract void PutOn(Item item);


    }
}

