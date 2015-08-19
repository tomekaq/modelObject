using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelingObjectTask;
using ModelingObjectTask.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WarriorParametr()
        {
            var Geralt = new Warrior();

            Console.WriteLine(Geralt);
            Geralt.Agility = 34;
            Console.WriteLine("Warrior Agility: {0}", Geralt.Agility);

            Geralt.DefensePoint = 342;
            Console.WriteLine("Warrior DefensePoint: {0}", Geralt.DefensePoint);

            Console.WriteLine("Warrior AttackValue(): {0}", Geralt.AttackValue());
            Console.WriteLine("Warrior DefenseValue(): {0}", Geralt.DefenseValue());

            Geralt.HealthPoints = 100;
            Console.WriteLine("Warrior HealthPoints: {0}", Geralt.HealthPoints);
            Console.WriteLine("Warrior HealthPointsNow: {0}", Geralt.HealthPointsNow);

            Geralt.HealthPointsNow -= 99;
            Console.WriteLine("Warrior HealthPointsNow: {0}", Geralt.HealthPointsNow);

            Geralt.ChangeHealth(-1);
            Console.WriteLine("Warrior HealthPointsNow: {0}", Geralt.HealthPointsNow);
            Console.WriteLine("Warrior is Alive?: {0}", Geralt.IsAlive);

            Geralt.MoneyAmount = 32;
            Console.WriteLine("Warrior MoneyAmount: {0}", Geralt.MoneyAmount);

            Geralt.Name = "Sinowłosy";
            Console.WriteLine("Warrior Name: {0}", Geralt.Name);

            Geralt.Name += "34";
            Console.WriteLine("Warrior Name: {0}", Geralt.Name);

            Geralt.Strength = 2;
            Console.WriteLine("Warrior Name: {0}", Geralt.Strength);


        }
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
            Console.WriteLine("Warrior is Alive?: {0}", Xardas.IsAlive);


            Xardas.MoneyAmount = 32;
            Console.WriteLine("Warrior MoneyAmount: {0}", Xardas.MoneyAmount);

            Xardas.Name = "Sinowłosy";
            Console.WriteLine("Warrior Name: {0}", Xardas.Name);

            Xardas.Name += "34";
            Console.WriteLine("Warrior Name: {0}", Xardas.Name);


        }
                [TestMethod]
        public void WarriorWearSword()
        {
            Weapon miecz = new Weapon()
            {
                Name = "super miecz",
                Attack = 23,
                Defense = 10,
                Weight = 32,
                Price = 100
            };
            
            Warrior Zbyszko = new Warrior() { Name = "Zbyszko"};
            Zbyszko.leftHand.PutOn(miecz);

        }
                [TestMethod]
        public void WarriorHasMoney()
        {
            List<Money> moneyList = new List<Money>();
            var bl = Enumerable.Range(1, 23).Select(x => new Money());
            moneyList.AddRange(bl);

            var Geralt = new Warrior();

            List<Money> moneyList2 = new List<Money>();
            var bl2 = Enumerable.Range(1, 23).Select(x => new Money() { Price = 2 });
            moneyList2.AddRange(bl);

            var Geralt2 = new Warrior();

            moneyList2.ForEach(x => Geralt.AddItem(x));
            Console.WriteLine(Geralt.MoneyAmount - 23);
            Console.WriteLine(Geralt.MoneyAmount );
        }
    }
}
