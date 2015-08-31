using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelingObjectTask;
using ModelingObjectTask.Items;
using ModelingObjectTask.BodyParts;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]

    public class MagTest1
    {
        [TestMethod]
        public void WizzardChangeWeapon()
        {
            new OracleDiceProvider().Add(1, 4).Build();

            Mag magiczny = new Mag();

            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Name = "super rozdzka",
                Attack = 11
            };

            Weapon superNIErozdzka = new Weapon()
            {
                Name = "super nie rozdzka",
                Attack = 11
            };

            MagicWeapon superrozdzkaprawa = new MagicWeapon()
            {
                Name = "super rozdzka",
                Attack = 11
            };

            magiczny.AddItem(superrozdzka);
            magiczny.PutOnBodyPart(superrozdzka, magiczny.leftHand);

            new OracleDiceProvider().Add(1).Add(1).Build();

            var goodAttack = magiczny.AttackValue();

            MagicWeapon zlarozdzka = new MagicWeapon()
            {
                Attack = 0
            };

            magiczny.AddItem(zlarozdzka);
            magiczny.PutOnBodyPart(zlarozdzka, magiczny.leftHand);

            var badAttack = magiczny.AttackValue();

            Assert.IsTrue(goodAttack > badAttack, "Attack with better weapon is greater");
        }
        [TestMethod]
        public void WizzardParametr()
        {
            new OracleDiceProvider().Add(1, 4).Build();

            var inputCapacity = 40;
            var inputHealthPoints = 1000;

            var Xardas = new Mag()
            {
                Capacity = inputCapacity,
                HealthPoints = inputHealthPoints,
                HealthPointsNow = inputHealthPoints
            };
            new OracleDiceProvider().Add(1).Build();

            Console.WriteLine(Xardas);
            Xardas.Agility = 34;
            Assert.AreEqual(Xardas.Agility, 34);

            Xardas.DefensePoint = 342;
            Console.WriteLine("Mag DefensePoint: {0}", Xardas.DefensePoint);
            Assert.AreEqual(Xardas.DefensePoint, 342);

            Console.WriteLine("Mag HealthPoints: {0}", Xardas.HealthPoints);
            Console.WriteLine("Mag HealthPointsNow: {0}", Xardas.HealthPointsNow);

            Assert.AreEqual(Xardas.HealthPoints, Xardas.HealthPointsNow);

            new OracleDiceProvider().Add(1).Add(2).Add(3).Add(4).Add(5).Build();
            Xardas.ChangeHealth(19);
            Console.WriteLine("Mag HealthPointsNow: {0}", Xardas.HealthPointsNow);

            Assert.AreEqual(981, Xardas.HealthPointsNow);

            new OracleDiceProvider().Add(1).Add(2).Add(3).Add(4).Add(5).Build();
            Xardas.ChangeHealth(-1);
            Console.WriteLine("Mag HealthPointsNow: {0}", Xardas.HealthPointsNow);
            Console.WriteLine("Mag is Alive? :{0}", Xardas.IsAlive);
            Assert.AreEqual(true, Xardas.IsAlive);

            List<Money> moneyList = new List<Money>();
            moneyList.AddRange(Enumerable.Range(1, 32).Select(x => new Money()));
            moneyList.ForEach(x => Xardas.AddItem(x));

            Console.WriteLine("Mag MoneyAmount: {0}", Xardas.MoneyAmount);
            Assert.AreEqual(32, Xardas.MoneyAmount);

            new OracleDiceProvider().Add(1).Build();
            Xardas.Name = "Sinowłosy";
            Console.WriteLine("Mag Name: {0}", Xardas);

            Assert.AreEqual("Sinowłosy", Xardas.Name);
        }

        [TestMethod]
        public void WizzardAttackHaveNotChangedWhenLeftHandDead()
        {
            new OracleDiceProvider().Add(1, 4).Build();

            var inputCapacity = 40;
            var inputHealthPoints = 40;

            Mag magiczny = new Mag()
            {
                Capacity = inputCapacity,
                HealthPoints = inputHealthPoints,
                HealthPointsNow = inputHealthPoints

            };
            magiczny.leftHand.Health = 0;

            new OracleDiceProvider().Add(1,4).Build();

            var AttackWithoutWeapon = magiczny.AttackValue();
            var DefenseWithoutWeapon = magiczny.DefenseValue();

            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 22

            };

            magiczny.AddItem(superrozdzka);
            magiczny.PutOnBodyPart(superrozdzka, magiczny.leftHand);

            var AttackWithWeapon = magiczny.AttackValue();
            var DefenseWithWeapon = magiczny.DefenseValue();

            Assert.AreEqual(AttackWithoutWeapon, AttackWithWeapon, "Attack with Weapon is greater");
            Assert.AreEqual(DefenseWithoutWeapon, DefenseWithWeapon, "Defense with Weapon is greater");
        }

        [TestMethod]
        public void WizzardAttackHaveNotChangedWhenRightHandDead()
        {
            new OracleDiceProvider().Add(1, 4).Build();

            Mag magiczny1 = new Mag();
            new OracleDiceProvider().Add(1, 4).Build();

            magiczny1.rightHand.Health = 0;

            var AttackWithoutWeapon = magiczny1.AttackValue();
            var DefenseWithoutWeapon = magiczny1.DefenseValue();

            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 22
            };

            magiczny1.AddItem(superrozdzka);
            magiczny1.PutOnBodyPart(superrozdzka, magiczny1.rightHand);

            var AttackWithWeapon = magiczny1.AttackValue();
            var DefenseWithWeapon = magiczny1.DefenseValue();

            Assert.AreEqual(AttackWithoutWeapon, AttackWithWeapon, "Adding weapon dont change attack");
            Assert.AreEqual(DefenseWithoutWeapon, DefenseWithWeapon, "Adding weapon dont change defense");
        }

        [TestMethod]
        public void WizzardAttackWithMagicWeapon()
        {
            new OracleDiceProvider().Add(1, 4).Build();

            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 30
            };

            Mag magiczny = new Mag()
            {
                Name = "magiczny"
            };

            new OracleDiceProvider().Add(1,3).Build();

            var offenseless = magiczny.AttackValue();

            Assert.AreEqual(4, offenseless, "Wizzard defense ");

            magiczny.AddItem(superrozdzka);
            magiczny.PutOnBodyPart(superrozdzka, magiczny.leftHand);

            var attackWithWeaponInLeftHand = magiczny.AttackValue();

            Assert.AreEqual(34, attackWithWeaponInLeftHand, "Wizzard defense ");

            magiczny.AddItem(superrozdzka);
            magiczny.PutOnBodyPart(superrozdzka, magiczny.rightHand);

            var attackWithWeaponInTwoHand = magiczny.AttackValue();

            Assert.AreEqual(64, attackWithWeaponInTwoHand, "Wizzard defense ");
        }

        [TestMethod]
        public void WizzardDefenseShouldBeRelatedToWearedItems()
        {
            //given
            Armour superzbroja = new Armour()
            {
                Defense = 20
            };
            Helmet superhelm = new Helmet()
            {
                Name = "super Hełm",
                Defense = 20
            };

            Shield superTarcza = new Shield()
            {
                Defense = 20
            };
            Trousers jeansy = new Trousers()
            {
                Defense = 20
            };
            new OracleDiceProvider().Add(1, 4).Build();

            Mag magiczny = new Mag();

            //when
            new OracleDiceProvider().Add(1, 2).Build();
            var defValue = magiczny.DefenseValue();

            magiczny.AddItem(superhelm);
            magiczny.PutOnBodyPart(superhelm, magiczny.head);

            magiczny.AddItem(jeansy);
            magiczny.PutOnBodyPart(jeansy, magiczny.legs);

            magiczny.AddItem(superTarcza);
            magiczny.PutOnBodyPart(superTarcza, magiczny.leftHand);

            magiczny.AddItem(superzbroja);
            magiczny.PutOnBodyPart(superzbroja, magiczny.body);

            var fullArmorDefValue = magiczny.DefenseValue();

            //then
            Assert.IsTrue(defValue < fullArmorDefValue, "Defense value should be greater when you wear something");
        }

        [TestMethod]
        public void WizzardFirstPutOn()
        {
            new OracleDiceProvider().Add(1, 4).Build();

            Mag magiczny = new Mag();
            Armour superzbroja = new Armour()
            {
                Defense = 20
            };

            magiczny.AddItem(superzbroja);
            magiczny.PutOnBodyPart(superzbroja, magiczny.body);

            Assert.AreEqual(magiczny.body.Clothes.FirstOrDefault(), superzbroja);
            //Character should wear something he put on
        }

        [TestMethod]
        public void WizzardNextPutOn()
        {
            new OracleDiceProvider().Add(1, 4).Build();

            Mag magiczny = new Mag();
            Armour superzbroja1 = new Armour()
            {
                Defense = 20
            };
            Armour superzbroja2 = new Armour()
            {
                Defense = 20
            };
            Armour superzbroja3 = new Armour()
            {
                Defense = 20
            };

            magiczny.AddItem(superzbroja3);
            magiczny.PutOnBodyPart(superzbroja3, magiczny.body);
  
            Assert.AreEqual(magiczny.body.Clothes.FirstOrDefault(), superzbroja3);
            //Character should wear something he put on
        }


        [TestMethod]
        public void WizzardHeadChangeHealth()
        {
            new OracleDiceProvider().Add(1, 4).Build();


            var inputCapacity = 40;
            var inputHealthPoints = 40;

            var Xardas = new Mag()
            {
                Capacity = inputCapacity,
                HealthPoints = inputHealthPoints,
                HealthPointsNow = inputHealthPoints
            };
            Helmet superhelm = new Helmet()
            {
                Name = "super Hełm",
                Defense = 20
            };

            Xardas.AddItem(superhelm);
            Xardas.PutOnBodyPart(superhelm, Xardas.head);

            new OracleDiceProvider().Add(1).Build();
            Xardas.head.ChangeHealth(21);
            Assert.AreEqual(199, Xardas.head.Health);
            Assert.AreEqual(true, Xardas.head.Alive);
        }

        [TestMethod]
        public void WizzardEquipWithStandardWeapon()
        {
            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 30
            };

        }
        [TestMethod]
        public void WizzardEquipWithMagicWeapon()
        {
            new OracleDiceProvider().Add(1, 4).Build();

            var inputCapacity = 40;
            var inputHealthPoints = 40;

            var Xardas = new Mag()
            {
                Capacity = inputCapacity,
                HealthPoints = inputHealthPoints,
                HealthPointsNow = inputHealthPoints
            };

            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 30
            };
            Xardas.AddItem(superrozdzka);
            Assert.IsTrue(Xardas.equipment.Count == 1);

        }
        [TestMethod]
        public void WizzardKillHimGo()
        {
            new OracleDiceProvider().Add(1, 4).Build();

            var inputCapacity = 40;
            var inputHealthPoints = 40;

            var Xardas = new Mag()
            {
                Capacity = inputCapacity,
                HealthPoints = inputHealthPoints,
                HealthPointsNow = inputHealthPoints
            };

            new OracleDiceProvider().Add(1, 5).Build();
            Xardas.ChangeHealth(1200);
            Assert.IsTrue(!Xardas.IsAlive);
        }

        [TestMethod]
        public void WizzardHealthUnderLimit()
        {
            new OracleDiceProvider().Add(1, 4).Build();

            var inputCapacity = 40;
            var inputHealthPoints = 1000;
            var Xardas = new Mag()
            {
                Capacity = inputCapacity,
                HealthPoints = inputHealthPoints,
                HealthPointsNow = inputHealthPoints
            };

            Xardas.ChangeHealth(-1200);

            Assert.AreEqual(inputHealthPoints, Xardas.HealthPointsNow);
            Assert.IsTrue(Xardas.IsAlive);
        }

        [TestMethod]
        public void WizzardLegsChangeHealth()
        {
            new OracleDiceProvider().Add(1, 4).Build();

            var inputCapacity = 40;
            var inputHealthPoints = 2000;
            var Xardas = new Mag()
            {
                Capacity = inputCapacity,
                HealthPoints = inputHealthPoints,
                HealthPointsNow = inputHealthPoints
            };

            Xardas.legs.ChangeHealth(200);
            Assert.IsTrue(Xardas.legs.Health <= 0);
            Assert.AreEqual(false, Xardas.legs.Alive);

        }

        [TestMethod]
        public void WizzardUsingWeaponShouldBeRelatedToAlive()
        {
            new OracleDiceProvider().Add(1, 4).Build();

            var inputCapacity = 40;
            var inputHealthPoints = 2000;
            var Xardas = new Mag()
            {
                Capacity = inputCapacity,
                HealthPoints = inputHealthPoints,
                HealthPointsNow = inputHealthPoints
            };

            new OracleDiceProvider().Add(1, 2).Build();

            var XardasAttackFirst = Xardas.AttackValue();

            Xardas.leftHand.ChangeHealth(200);
            Assert.AreEqual(false, Xardas.leftHand.Alive);

            var XardasAttackSecond = Xardas.AttackValue();

            Assert.AreEqual(XardasAttackFirst, XardasAttackSecond);
        }
    }
}



