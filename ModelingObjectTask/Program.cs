using ModelingObjectTask.BodyParts;
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
            Armour superzbroja = new Armour()
            {
                Defense = 10
            };

            Warrior Geralt = new Warrior() { body = new Body() { Health = 10000} };
            Geralt.Body = new Body() { Health = 10000 };
     //       Geralt.rightHand.PutOn(miecz);
       //     var bb = Geralt.rightHand.Item;
            Console.ReadLine();
        }
    }
}
