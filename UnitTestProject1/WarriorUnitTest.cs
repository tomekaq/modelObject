using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelingObjectTask;
using ModelingObjectTask.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class WarriorUnitTest
    {
        [TestMethod]
        public void WarriorParametr()
        {
            var Geralt = new Warrior() { HealthPoints = 2000, HealthPointsNow = 2000 };

            Console.WriteLine(Geralt);
            Geralt.Agility = 34;
            Console.WriteLine("Warrior Agility: {0}", Geralt.Agility);

            Console.WriteLine("Warrior DefensePoint: {0}", Geralt.DefensePoint);
            Geralt.DefensePoint = 342;
            Console.WriteLine("Warrior DefensePoint: {0}", Geralt.DefensePoint);

            Console.WriteLine("Warrior AttackValue(): {0}", Geralt.AttackValue());
            Console.WriteLine("Warrior DefenseValue(): {0}", Geralt.DefenseValue());

          //  Geralt.HealthPoints = 100;
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
            Console.WriteLine(Geralt.MoneyAmount);
        }
        [TestMethod]
        public void WarriorWearFullArmour()
        {
            Armour superzbroja = new Armour()
            {
                Defense = 10
            };
            Helmet superhelm = new Helmet()
            {
                Name = "super Hełm",
                Defense = 10
            };

            Shield superTarcza = new Shield()
            {
                Defense = 10
            };
            Trousers jeansy = new Trousers()
            {
                Defense = 10
            };

            Warrior wojownik = new Warrior();

            Console.WriteLine("{0} bez zbroji {1}", wojownik.Name, wojownik.DefenseValue());

            wojownik.body.PutOn(superzbroja);
            wojownik.head.PutOn(superhelm);
            wojownik.legs.PutOn(jeansy);
            wojownik.leftHand.PutOn(superTarcza);


            Console.WriteLine("{0} z zalozona zbroja {1}", wojownik.Name, wojownik.DefenseValue());

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

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };

            Console.WriteLine("Warrior Attack without weapon: {0}", Zbyszko.AttackValue());

            Zbyszko.rightHand.PutOn(miecz);

            Console.WriteLine("Warrior Attack with sword in right hand: {0}", Zbyszko.AttackValue());

            Zbyszko.leftHand.PutOn(miecz);

            Console.WriteLine("Warrior Attack with sword in right hand: {0}", Zbyszko.AttackValue());
        }

        [TestMethod]
        public void WarriorWearArmour()
        {
            Armour superzbroja = new Armour();

            Console.WriteLine("Zbroja {0}", superzbroja.Defense);

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };

            Console.WriteLine("Obrona Postaci bez zbroji: {0}", Zbyszko.DefenseValue());

            Zbyszko.body.PutOn(superzbroja);

            Console.WriteLine("Obrona Postaci z zalozona zbroja: {0}", Zbyszko.DefenseValue());

        }

        [TestMethod]
        public void WarriorWearHelmet()
        {
            Helmet superhelm = new Helmet()
            {
                Name = "super Helm"
            };

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };

            Console.WriteLine("Obrona Postaci bez hełmu: {0}", Zbyszko.DefenseValue());

            Zbyszko.head.PutOn(superhelm);

            Console.WriteLine("Obrona Postaci z zalozonym hełmem: {0}", Zbyszko.DefenseValue());
        
        }

        [TestMethod]
        public void WarriorWearShield()
        {
            Shield superTarcza = new Shield() { Defense = 2};

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };
  
            Console.WriteLine("Obrona Postaci bez tarczy: {0}", Zbyszko.DefenseValue());

            Zbyszko.leftHand.PutOn(superTarcza);

            Console.WriteLine("Obrona Postaci z zalozona tarcza: {0}", Zbyszko.DefenseValue());

            Zbyszko.rightHand.PutOn(superTarcza);

            Console.WriteLine("Obrona Postaci z zalozonymi dwiem tarczami: {0}", Zbyszko.DefenseValue());

        }

        [TestMethod]
        public void WarriorWearTrousers()
        {
            Trousers jeansy = new Trousers();

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };

            Console.WriteLine("Obrona Postaci bez spodnii: {0}", Zbyszko.DefenseValue());

            Zbyszko.legs.PutOn(jeansy);

            Console.WriteLine("Obrona Postaci z zalozonymi spodniami: {0}", Zbyszko.DefenseValue());

        }
    }
}
