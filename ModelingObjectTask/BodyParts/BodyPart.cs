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
            get{return items;}
            protected set { items = value; }
         
            //private set{Items = value;}
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

        public virtual void PutOn<T>(T item) where T:Item
        {
            var t = Items.Where(x => x is T);
            Items.Remove(t.FirstOrDefault());
            this.Items.Add(item);
        }

    }
}

