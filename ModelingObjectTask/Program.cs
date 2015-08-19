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
            Weapon miecz = new Weapon() { Attack = 11,
            Defense =11};
            Warrior Geralt = new Warrior();
            Geralt.rightHand.PutOn(miecz);
            var bb = Geralt.rightHand.Item;
            Console.ReadLine();
        }
    }
}
