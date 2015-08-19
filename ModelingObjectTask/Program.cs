using ModelingObjectTask.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelingObjectTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Weapon miecz = new Weapon()
            {
                Name = "super miecz",
                Attack = 23,
                Defense = 10,
                Weight = 32,
                Price = 100
            };





            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };
            Zbyszko.leftHand.PutOn(miecz);
            Zbyszko.legs.PutOn(miecz);
            
            Console.ReadLine();
        }
    }
}
