using ModelingObjectTask.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelingObjectTask.BodyParts
{
    public abstract class BodyPart
    {
        //protected bool alive;
        protected int health; 

        protected List<Item> items = new List<Item>();


        public BodyPart()
        {
            Alive = true;
        }

        public bool Alive
        {
            get;
            private set;
        }

        public IEnumerable<Clothes> Clothes
        {
            get
            {
                return items.Where(i=> i is Clothes).Cast<Clothes>();
            }
        }

        public List<Item> Items
        {
            get
            {
                return items;
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

        public virtual void PutOn(Item item)
        {
            var t = Items.Where(x => x.GetType() == item.GetType());
            Items.Remove(t.FirstOrDefault());
            this.Items.Add(item);
        }

    }
}

