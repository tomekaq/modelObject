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
                Attack = 100
            };

            Weapon supermieczor = new Weapon()
            {
                Attack = 100
            };

            HealthPotion superziolko = new HealthPotion()
            {
                Health = 20
            };

            Xardas.AddItem(superrozdzka);
            Xardas.PutOnBodyPart(superrozdzka, Xardas.rightHand);

            Geralt.AddItem(supermieczor);
            Geralt.PutOnBodyPart(supermieczor, Geralt.rightHand);
            int i = 0;
            Console.WriteLine("{0}", Xardas.ToString());
            Console.WriteLine("{0}", Geralt.ToString());
            Thread.Sleep(10000);
            Console.WriteLine("Ready");

            Thread.Sleep(1000);
            Console.WriteLine("Steady");
            Thread.Sleep(1000);
            Console.WriteLine("Go");

            //      Thread.Sleep(1000);
            while (Xardas.IsAlive && Geralt.IsAlive)
            {
                Thread.Sleep(50);
                Xardas.Attack(Geralt);
                Console.WriteLine("Xardas attack Geralt!");
                Thread.Sleep(50);
                Console.WriteLine("Xardas health: {0}", Xardas.HealthPointsNow);
                Thread.Sleep(50);
                Console.WriteLine("Gerlat health: {0}", Geralt.HealthPointsNow);
                if ((Xardas.IsAlive && Geralt.IsAlive))
                {
                    Geralt.Attack(Xardas);
                    Thread.Sleep(50);
                    Console.WriteLine("Geralt attack Xardas!");
                    Thread.Sleep(50);
                    Console.WriteLine("Xardas health: {0}", Xardas.HealthPointsNow);
                    Thread.Sleep(50);
                    Console.WriteLine("Gerlat health: {0}", Geralt.HealthPointsNow);
                    superziolko.Apply(Geralt);
                    //superziolko.Apply(Geralt);
                    Console.WriteLine("Gerlat health po superziolku: {0}", Geralt.HealthPointsNow);
                } i++;

            }
            Console.WriteLine("End fight!");
            Console.WriteLine("Who win?");
            if (Xardas.IsAlive)
            {
                if (!Geralt.head.Alive)
                    Console.WriteLine("Xardas cut Geralt head!");
                Console.WriteLine("Xardas win");

            }
            else
            {
                if (!Xardas.head.Alive)
                    Console.WriteLine("Geralt cut Xardas head!");
                Console.WriteLine("Geralt win");
            }
            Console.WriteLine();
            Console.WriteLine("Geralt");
            Console.WriteLine(Geralt.ShowBodyInfo());

            Console.WriteLine("Xardas");
            Console.WriteLine(Xardas.ShowBodyInfo());
            Console.ReadLine();
        }
    }
}
