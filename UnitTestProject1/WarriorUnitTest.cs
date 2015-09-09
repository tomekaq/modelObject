using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelingObjectTask;
using ModelingObjectTask.BodyParts;
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
            moneyList2.AddRange(Enumerable.Range(1, 23)
                                .Select(x => new Money() { Price = 2, Weight = 2 }));

            var Geralt2 = new Warrior()
            {
                Capacity = 40
            };

            moneyList2.ForEach(x => Geralt2.AddItem(x));

            Assert.AreEqual(40, Geralt2.MoneyAmount);
        }

        [TestMethod]
        public void WarriorParametr()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            var Geralt = new Warrior()
            {
                HealthPoints = 200,
                HealthPointsNow = 1000
            };

            //Console.WriteLine(Geralt);
            Geralt.Agility = 34;
            Console.WriteLine("Warrior Agility: {0}", Geralt.Agility);

            Assert.AreEqual(34, Geralt.Agility);
            Console.WriteLine("Warrior DefensePoint: {0}", Geralt.DefensePoint);
            Geralt.DefensePoint = 342;
            Console.WriteLine("Warrior DefensePoint: {0}", Geralt.DefensePoint);
            Assert.AreEqual(342, Geralt.DefensePoint);

            new OracleDiceProvider().Add(1).Add(1).Build();
            Console.WriteLine("Warrior AttackValue(): {0}", Geralt.AttackValue());
            Console.WriteLine("Warrior DefenseValue(): {0}", Geralt.DefenseValue());

            //  Geralt.HealthPoints = 100;
            Console.WriteLine("Warrior HealthPoints: {0}", Geralt.HealthPoints);
            Console.WriteLine("Warrior HealthPointsNow: {0}", Geralt.HealthPointsNow);

            Geralt.HealthPointsNow -= 199;// protected
            Console.WriteLine("Warrior HealthPointsNow: {0}", Geralt.HealthPointsNow);

            new OracleDiceProvider().Add(1).Add(2).Add(3).Add(4).Add(5).Build();
            Geralt.ChangeHealth(-1);
            Console.WriteLine("Warrior HealthPointsNow: {0}", Geralt.HealthPointsNow);
            Console.WriteLine("Warrior is Alive?: {0}", Geralt.IsAlive);
            Assert.AreEqual(true, Geralt.IsAlive);

            Geralt.Name = "Sinowłosy";
            Console.WriteLine("Warrior Name: {0}", Geralt.Name);
            Assert.AreEqual("Sinowłosy", Geralt.Name);

            Geralt.Strength = 2;
            Console.WriteLine("Warrior Name: {0}", Geralt.Strength);
            Assert.AreEqual(2, Geralt.Strength);
        }

        [TestMethod]
        public void WarriorTestHealth()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();
            Warrior wojownik = new Warrior()
            {
                HealthPoints = 200,
                HealthPointsNow = 200
            };

            new OracleDiceProvider().Add(1).Add(2).Add(3).Add(4).Add(5).Build();
            wojownik.ChangeHealth(-30);

       //     Assert.AreEqual(0, wojownik.Agility, "Warrior Agility without legs");
        }

        [TestMethod]
        public void WarriorWearArmour()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Armour superzbroja = new Armour();

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };
            new OracleDiceProvider().Add(1).Add(1).Build();
            var defValue = Zbyszko.DefenseValue();

            Zbyszko.AddItem(superzbroja);
            Zbyszko.PutOnBodyPart(superzbroja, Zbyszko.body);

            var fullArmorDefValue = Zbyszko.DefenseValue();

            Assert.IsTrue(defValue < fullArmorDefValue, "Defense value should be greater when you wear something");
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

            wojownik.AddItem(superzbroja);
            wojownik.PutOnBodyPart(superzbroja, wojownik.body);

            wojownik.AddItem(superhelm);
            wojownik.PutOnBodyPart(superhelm, wojownik.head);

            wojownik.AddItem(jeansy);
            wojownik.PutOnBodyPart(jeansy, wojownik.legs);

            wojownik.AddItem(superTarcza);
            wojownik.PutOnBodyPart(superTarcza, wojownik.leftHand);


            var withArmour = wojownik.DefenseValue();

            Assert.IsTrue(withArmour > withoutArmour, "With armour defense are greater");
        }

        [TestMethod]
        public void WarriorWearHelmet()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();
            Helmet superhelm = new Helmet()
            {
                Name = "super Helm"
            };

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };
            new OracleDiceProvider().Add(1).Add(1).Build();
            var defValue = Zbyszko.DefenseValue();

            Zbyszko.AddItem(superhelm);
            Zbyszko.PutOnBodyPart(superhelm, Zbyszko.head);

            var defenseWithHelmet = Zbyszko.DefenseValue();

            Assert.IsTrue(defValue < defenseWithHelmet, "Defense value should be greater when you wear something");
        }

        [TestMethod]
        public void WarriorWearShield()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Shield superTarcza = new Shield()
            {
                Defense = 2
            };
            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };

            new OracleDiceProvider().Add(1).Add(1).Add(1).Build();

            var defaultValue = Zbyszko.DefenseValue();

            Zbyszko.AddItem(superTarcza);
            Zbyszko.PutOnBodyPart(superTarcza, Zbyszko.leftHand);

            var defenseWithOneShield = Zbyszko.DefenseValue();

            Zbyszko.AddItem(superTarcza);
            Zbyszko.PutOnBodyPart(superTarcza, Zbyszko.rightHand);

            var defenseWithTwoShield = Zbyszko.DefenseValue();

            Assert.IsTrue(defaultValue < defenseWithOneShield, "Defense value should be greater with one shield");
            Assert.IsTrue(defenseWithOneShield < defenseWithTwoShield, "Defense value should be greater with two shield ");
        }

        [TestMethod]
        public void WarriorWearSword()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Weapon miecz = new Weapon()
            {
                Name = "super miecz",
                Attack = 23,
                Weight = 32,
                Price = 100
            };

            Warrior Zbyszko = new Warrior()
            {
                Name = "Zbyszko",
                Capacity = 40
            };

            new OracleDiceProvider().Add(1).Add(1).Add(1).Build();
            var attackWithoutSword = Zbyszko.AttackValue();

            Zbyszko.AddItem(miecz);
            Zbyszko.PutOnBodyPart(miecz, Zbyszko.rightHand);
            var attackWithSwordInLeftHand = Zbyszko.AttackValue();

            Assert.IsTrue(attackWithoutSword < attackWithSwordInLeftHand);

            Zbyszko.AddItem(miecz);
            Zbyszko.PutOnBodyPart(miecz, Zbyszko.leftHand);

            var attackWithSwordInTwoHand = Zbyszko.AttackValue();

            Assert.IsTrue(attackWithSwordInLeftHand < attackWithSwordInTwoHand);
        }

        [TestMethod]
        public void WarriorWearTrousers()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Trousers jeansy = new Trousers()
            {
                Defense = 10
            };

            Warrior Zbyszko = new Warrior()
            {
                Name = "Zbyszko"
            };

            new OracleDiceProvider().Add(1).Add(1).Build();
            var defenseWithoutTrousers = Zbyszko.DefenseValue();

            Zbyszko.AddItem(jeansy);
            Zbyszko.PutOnBodyPart(jeansy, Zbyszko.legs);

            var defenseWithTrousers = Zbyszko.DefenseValue();

            Assert.IsTrue(defenseWithoutTrousers < defenseWithTrousers, "Defense value should be greater with two shield ");
        }
    }
}
