﻿
namespace ModelingObjectTask.Items
{
    public abstract class Clothes:Item
    {
        public int Defense { get; set; }

        public Clothes()
        {
            Defense = 1;
        }
    }
}
