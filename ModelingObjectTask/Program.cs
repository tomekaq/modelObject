using ModelingObjectTask.Items;
using System;

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
            Zbyszko.lewaReka.PutOn(miecz);
            Zbyszko.nogi.PutOn(miecz);
        }
    }
}
