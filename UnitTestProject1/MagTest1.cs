﻿using System;
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
        public void MagChangeWeapon()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

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

            magiczny.leftHand.PutOn(superrozdzka);

            new OracleDiceProvider().Add(1).Add(1).Build();

            var goodAttack = magiczny.AttackValue();

            MagicWeapon zlarozdzka = new MagicWeapon()
            {
                Attack = 0
            };

            magiczny.leftHand.PutOn(zlarozdzka);
            var badAttack = magiczny.AttackValue();

            Assert.IsTrue(goodAttack > badAttack, "Attack with better weapon is greater");
        }
        [TestMethod]
        public void MagParametr()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            var Xardas = new Mag() 
            {
                Capacity = 40,
                HealthPoints = 200,
                HealthPointsNow = 200
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

            Assert.AreEqual(181, Xardas.HealthPointsNow);

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
        public void MagTryUseWeaponInLeftHand()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Mag magiczny = new Mag()
            {
                leftHand = new LeftHand()
                {
                    Health = 0
                }
            };

            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            var AttackWithoutWeapon = magiczny.AttackValue();
            var DefenseWithoutWeapon = magiczny.DefenseValue();

            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 22,
                Defense = 200
            };

            magiczny.leftHand.PutOn(superrozdzka);

            var AttackWithWeapon = magiczny.AttackValue();
            var DefenseWithWeapon = magiczny.DefenseValue();

            Assert.AreEqual(AttackWithoutWeapon, AttackWithWeapon, "Attack with Weapon is greater");
            Assert.AreEqual(DefenseWithoutWeapon, DefenseWithWeapon, "Defense with Weapon is greater");
        }

        [TestMethod]
        public void MagTryUseWeaponInRightHand()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Mag magiczny1 = new Mag()
            {
                rightHand = new RightHand()
                {
                    Health = 0
                }
            };
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            var AttackWithoutWeapon = magiczny1.AttackValue();
            var DefenseWithoutWeapon = magiczny1.DefenseValue();

            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 22,
                Defense = 200
            };

            magiczny1.rightHand.PutOn(superrozdzka);

            var AttackWithWeapon = magiczny1.AttackValue();
            var DefenseWithWeapon = magiczny1.DefenseValue();

            Assert.AreEqual(AttackWithoutWeapon, AttackWithWeapon, "Adding weapon dont change attack");
            Assert.AreEqual(DefenseWithoutWeapon, DefenseWithWeapon, "Adding weapon dont change defense");
        }

        [TestMethod]
        public void MagWearMagicWeapon()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 30
            };

            Mag magiczny = new Mag() { 
            Name = "magiczny"};

            new OracleDiceProvider().Add(1).Add(1).Add(1).Build();

            var offenseless = magiczny.AttackValue();

            Assert.AreEqual(4, offenseless, "Wizzard defense ");

            magiczny.leftHand.PutOn(superrozdzka);

            var attackWithWeaponInLeftHand = magiczny.AttackValue();

            Assert.AreEqual(34, attackWithWeaponInLeftHand, "Wizzard defense ");

            magiczny.rightHand.PutOn(superrozdzka);

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
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Mag magiczny = new Mag();

            //when
            new OracleDiceProvider().Add(1).Add(1).Build();
            var defValue = magiczny.DefenseValue();

            magiczny.head.PutOn(superhelm);
            magiczny.legs.PutOn(jeansy);
            magiczny.leftHand.PutOn(superTarcza);
            magiczny.body.PutOn(superzbroja);

            var fullArmorDefValue = magiczny.DefenseValue();
            
            //then
            Assert.IsTrue(defValue < fullArmorDefValue, "Defense value should be greater when you wear something");
        }

        [TestMethod]
        public void WizzardFirstPutOn()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Mag magiczny = new Mag();
            Armour superzbroja = new Armour()
            {
                Defense = 20
            };

            magiczny.body.PutOn(superzbroja);
         
            Assert.AreEqual(magiczny.body.Clothes.FirstOrDefault(), superzbroja);
            //Character should wear something he put on
        }

        [TestMethod]
        public void WizzardNextPutOn()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

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
           
            magiczny.body.PutOn(superzbroja3);

            Assert.AreEqual(magiczny.body.Clothes.FirstOrDefault(), superzbroja3);
            //Character should wear something he put on
        }

        [TestMethod]
        public void WizzardHeadChangeHealth()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            var Xardas = new Mag()
            {
                Capacity = 40,
                HealthPoints = 200,
                HealthPointsNow = 200
            };

            Helmet superhelm = new Helmet()
            {
                Name = "super Hełm",
                Defense = 20
            };

            Xardas.head.PutOn(superhelm);

            new OracleDiceProvider().Add(1).Build();
            Xardas.head.ChangeHealth(21);
            Assert.AreEqual(199, Xardas.head.Health);
            Assert.AreEqual(true, Xardas.head.Alive);
        }

        [TestMethod]
        public void WizzardKillHimGo()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            var Xardas = new Mag()
            {
                Capacity = 40,
                HealthPoints = 2000,
                HealthPointsNow = 2000
            };

            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Add(1).Build();
            Xardas.ChangeHealth(1200);
            Assert.IsTrue(!Xardas.IsAlive);
        }

        [TestMethod]
        public void WizzardHealthUnderLimit()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            var healthPoint = 2000;
            var Xardas = new Mag()
            {
                Capacity = 40,
                HealthPoints = healthPoint,
                HealthPointsNow = healthPoint
            };

            Xardas.ChangeHealth(-1200);

            Assert.AreEqual(healthPoint, Xardas.HealthPointsNow);
            Assert.IsTrue(Xardas.IsAlive);
        }

        [TestMethod]
        public void WizzardLegsChangeHealth()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            var Xardas = new Mag()
            {
                Capacity = 40,
                HealthPoints = 2200,
                HealthPointsNow = 2200
            };

            Xardas.legs.ChangeHealth(200);
            Assert.IsTrue(Xardas.legs.Health <= 0);
            Assert.AreEqual(false, Xardas.legs.Alive);
        
        }
        
        [TestMethod]
        public void WizzardUsingWeaponShouldBeRelatedToAlive()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            var Xardas = new Mag()
            {
                Capacity = 40,
                HealthPoints = 2200,
                HealthPointsNow = 2200
            };
            new OracleDiceProvider().Add(1).Add(1).Build();

            var XardasAttackFirst = Xardas.AttackValue();

            Xardas.leftHand.ChangeHealth(200);
            Assert.AreEqual(false, Xardas.leftHand.Alive);

            var XardasAttackSecond = Xardas.AttackValue();

            Assert.AreEqual(XardasAttackFirst, XardasAttackSecond);
        }
    }
}



