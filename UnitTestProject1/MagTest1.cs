using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelingObjectTask;
using ModelingObjectTask.Items;

namespace UnitTestProject1
{
    [TestClass]
    public class MagTest1
    {
        [TestMethod]
        public void MagParametr()
        {
            var Xardas = new Mag();

            Console.WriteLine(Xardas);
            Xardas.Agility = 34;
            Console.WriteLine("Warrior Agility: {0}", Xardas.Agility);

            Xardas.DefensePoint = 342;
            Console.WriteLine("Warrior DefensePoint: {0}", Xardas.DefensePoint);

            Xardas.HealthPoints = 100;
            Console.WriteLine("Warrior HealthPoints: {0}", Xardas.HealthPoints);
            Console.WriteLine("Warrior HealthPointsNow: {0}", Xardas.HealthPointsNow);

            Xardas.HealthPointsNow -= 99;
            Console.WriteLine("Warrior HealthPointsNow: {0}", Xardas.HealthPointsNow);

            Xardas.ChangeHealth(-1);
            Console.WriteLine("Warrior HealthPointsNow: {0}", Xardas.HealthPointsNow);
            Console.WriteLine("Warrior is Alive ?: {0}", Xardas.IsAlive);

            Xardas.MoneyAmount = 32;
            Console.WriteLine("Warrior MoneyAmount: {0}", Xardas.MoneyAmount);

            Xardas.Name = "Sinowłosy";
            Console.WriteLine("Warrior Name: {0}", Xardas.Name);

            Xardas.Name += "34";
            Console.WriteLine("Warrior Name: {0}", Xardas.Name);
        }
        [TestMethod]
        public void MagWearFullArmour()
        {
            Armour superzbroja = new Armour()
            {
                Defense = 10
            };
            Helmet superhelm = new Helmet()
            {
                Name = "super Heøm"
            };

            Shield superTarcza = new Shield()
            {
                Defense = 10
            };
            Trousers jeansy = new Trousers()
            {
                Defense = 10
            };

            Mag magiczny = new Mag();

          //  Console.WriteLine(magiczny.DefensePoint);

            magiczny.head.PutOn(superhelm);
            magiczny.legs.PutOn(jeansy);
            magiczny.leftHand.PutOn(superTarcza);
            magiczny.body.PutOn(superzbroja);

            Console.WriteLine(magiczny.DefensePoint);

        }
    }
}












