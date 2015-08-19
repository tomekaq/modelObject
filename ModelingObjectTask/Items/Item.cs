﻿
namespace ModelingObjectTask.Items
{
    public abstract class Item
    {
        protected string name;
        protected int price;
        protected int weight;

        public string Name { get { return name; } set { name = value; } }
        public int Price { get { return price; } set { price = (value> 0? value: 0); } }
        public int Weight { get { return weight; } set { weight = (value > 0 ? value : 0);; } }

    }
}
