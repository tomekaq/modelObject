using ModelingObjectTask.BodyParts;
using ModelingObjectTask.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ModelingObjectTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior Geralt = new Warrior()
            {
                HealthPoints = 1000,
                HealthPointsNow = 1000
            };

            var Xardas = new Mag()
            {
                Capacity = 40,
                HealthPoints = 1000,
                HealthPointsNow = 1000
            };

            var XardasHealthBefore = Xardas.HealthPointsNow;
            var GeraltHealthBefore = Geralt.HealthPointsNow;

            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 50
            };

            Weapon supermieczor = new Weapon()
            {
                Attack = 50
            };

            Xardas.AddItem(superrozdzka);
            Xardas.PutOnBodyPart(superrozdzka, Xardas.rightHand);

            Geralt.AddItem(supermieczor);
            Geralt.PutOnBodyPart(supermieczor, Geralt.rightHand);
            int i = 0;
            while (Xardas.IsAlive && Geralt.IsAlive)
            {
                Thread.Sleep(500);
                Xardas.Attack(Geralt);
                Console.WriteLine("Xardas attack Geralt!");
                if ((Xardas.IsAlive && Geralt.IsAlive))
                {
                    Geralt.Attack(Xardas);
                    Thread.Sleep(500);
                    Console.WriteLine("Geralt attack Xardas!");
                } i++;
                
            }Console.WriteLine("End fight!");
            Console.WriteLine("Who win?");
            if (Xardas.IsAlive)
                Console.WriteLine("Xardas win");
            else
                Console.WriteLine("Geralt win");
            Console.ReadLine();



        }
    }
}
