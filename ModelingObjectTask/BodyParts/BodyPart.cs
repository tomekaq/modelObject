﻿using ModelingObjectTask.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ModelingObjectTask.BodyParts
{
    public abstract class BodyPart
    {
        //protected bool alive;
        protected int health;
        public string Name { get; set; }

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
                return items.Where(i => i is Clothes).Cast<Clothes>();
            }
        }

        public ReadOnlyCollection<Item> Items
        {
            get 
            { 
                return items.AsReadOnly(); 
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

        public virtual void PutOn<T>(T item) where T : Item
        {
            var t = Items.Where(x => x is T);
            items.Remove(t.FirstOrDefault());
            this.items.Add(item);
        }

    }
}

