using ModelingObjectTask.Items;

namespace ModelingObjectTask.BodyParts
{
    public abstract class BodyPart
    {
        //protected bool alive;
        protected int health; 
        protected Clothes clothes;
        protected Item item;

        public abstract void PutOn(Item item);

        public BodyPart()
        {
            Alive = true;
        }

        public bool Alive
        {
            get;
            private set;
        }

        public Clothes Clothes
        {
            get
            {
                return clothes;
            }
            set
            {
                clothes = value;
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

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
                Alive = health > 0;
            }
        }
    }
}

