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
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            var Geralt = new Warrior() { HealthPoints = 2000, HealthPointsNow = 2000 };

            Console.WriteLine(Geralt);
            Geralt.Agility = 34;
            Console.WriteLine("Warrior Agility: {0}", Geralt.Agility);

            Console.WriteLine("Warrior DefensePoint: {0}", Geralt.DefensePoint);
            Geralt.DefensePoint = 342;
            Console.WriteLine("Warrior DefensePoint: {0}", Geralt.DefensePoint);

            new OracleDiceProvider().Add(1).Add(1).Build();
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
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();
            List<Money> moneyList = new List<Money>();
            moneyList.AddRange(Enumerable.Range(1, 23).Select(x => new Money()));

            var Geralt = new Warrior() 
            {
                Capacity = 40
            };
            
            moneyList.ForEach(x => Geralt.AddItem(x));

            Assert.AreEqual(23, Geralt.MoneyAmount);

            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();
            List<Money> moneyList2 = new List<Money>();
            moneyList.AddRange(Enumerable.Range(1, 23)
                                .Select(x => new Money() { Price = 2,Weight = 2 }));

            var Geralt2 = new Warrior()
            {
                Capacity = 40
            };

            moneyList2.ForEach(x => Geralt2.AddItem(x));

            Assert.AreEqual(40,Geralt2.MoneyAmount);
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

            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Warrior wojownik = new Warrior();

            new OracleDiceProvider().Add(1).Add(1).Build();
            var withoutArmour = wojownik.DefenseValue();

            wojownik.body.PutOn(superzbroja);
            wojownik.head.PutOn(superhelm);
            wojownik.legs.PutOn(jeansy);
            wojownik.leftHand.PutOn(superTarcza);

            var withArmour =wojownik.DefenseValue();

            Assert.IsTrue(withArmour > withoutArmour,"With armour defense are greater");
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

            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };

            new OracleDiceProvider().Add(1).Add(1).Add(1).Build();
            
            var attackWithoutSword = Zbyszko.AttackValue();

            Zbyszko.rightHand.PutOn(miecz);

            var attackWithSwordInLeftHand =  Zbyszko.AttackValue();

            Assert.IsTrue(attackWithoutSword < attackWithSwordInLeftHand);

            Zbyszko.leftHand.PutOn(miecz);

            var attackWithSwordInTwoHand = Zbyszko.AttackValue();

            Assert.IsTrue(attackWithSwordInLeftHand < attackWithSwordInTwoHand);
        }

        [TestMethod]
        public void WarriorWearArmour()
        {
            Armour superzbroja = new Armour();

            Console.WriteLine("Zbroja {0}", superzbroja.Defense);

            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };

            var defValue = Zbyszko.DefenseValue();

            Zbyszko.body.PutOn(superzbroja);

            var fullArmorDefValue =  Zbyszko.DefenseValue();

            Assert.IsTrue(defValue < fullArmorDefValue, "Defense value should be greater when you wear something");

        }

        [TestMethod]
        public void WarriorWearHelmet()
        {
            Helmet superhelm = new Helmet()
            {
                Name = "super Helm"
            };
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };

            var defValue = Zbyszko.DefenseValue();

            Zbyszko.head.PutOn(superhelm);

            var defenseWithHelmet = Zbyszko.DefenseValue();
               
            Assert.IsTrue(defValue < defenseWithHelmet, "Defense value should be greater when you wear something");

        }

        [TestMethod]
        public void WarriorWearShield()
        {
            Shield superTarcza = new Shield() { Defense = 2};

            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };

            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();
            Console.WriteLine("Obrona Postaci bez tarczy: {0}", Zbyszko.DefenseValue());

            var defaultValue = Zbyszko.DefenseValue();

            Zbyszko.leftHand.PutOn(superTarcza);

            var defenseWithOneShield  = Zbyszko.DefenseValue();

            Zbyszko.rightHand.PutOn(superTarcza);

            var defenseWithTwoShield = Zbyszko.DefenseValue(); 

            Assert.IsTrue(defaultValue < defenseWithOneShield, "Defense value should be greater with one shield");
            Assert.IsTrue(defenseWithOneShield < defenseWithTwoShield, "Defense value should be greater with two shield ");

        }

        [TestMethod]
        public void WarriorWearTrousers()
        {
            Trousers jeansy = new Trousers();

            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };

            new OracleDiceProvider().Add(1).Add(1).Build();
            Console.WriteLine("Obrona Postaci bez spodnii: {0}", Zbyszko.DefenseValue());

            Zbyszko.legs.PutOn(jeansy);

            Console.WriteLine("Obrona Postaci z zalozonymi spodniami: {0}", Zbyszko.DefenseValue());

        }
    }
}
