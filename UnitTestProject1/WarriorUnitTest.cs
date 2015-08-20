﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var Geralt = new Warrior();

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
        public void WarriorWearSword()
        {
            Weapon miecz = new Weapon()
            {
                Name = "super miecz",
    //            Attack = 23,
  //              Defense = 10,
                Weight = 32,
                Price = 100
            };

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };
            Zbyszko.rightHand.PutOn(miecz);

            Console.WriteLine("Warrior Helmet Name{0}", Zbyszko.rightHand.Item.Name);
     
        }


        [TestMethod]
        public void WarriorWearTrousers()
        {
            Trousers jeansy = new Trousers(); 

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };
            Zbyszko.legs.PutOn(jeansy);

            Console.WriteLine("Spodnie {0}", Zbyszko.legs.Clothes.Defense);

            Trousers noweJeansy = new Trousers() { Defense = 22};

            Warrior Zbyszko2 = new Warrior() { Name = "Zbyszko2" };
            Zbyszko2.legs.PutOn(noweJeansy);

            Console.WriteLine("{0} Spodnie {1}", Zbyszko2.Name, Zbyszko2.legs.Clothes.Defense);

        }
        [TestMethod]
        public void WarriorWearHelmet()
        {
            Helmet superhelm = new Helmet()
            {
                Name = "super Heøm"
            };

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };
            Zbyszko.head.PutOn(superhelm);

            Console.WriteLine("Warrior Helmet Name: {0}", Zbyszko.head.Clothes.Name);
        }

        [TestMethod]
        public void WarriorWearArmour()
        {
            Armour superzbroja = new Armour();

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };
            Zbyszko.body.PutOn(superzbroja);
        }

        [TestMethod]
        public void WarriorWearShield()
        {
            Shield superTarcza = new Shield();

            Warrior Zbyszko = new Warrior() { Name = "Zbyszko" };
            Zbyszko.leftHand.PutOn(superTarcza);
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
        public void WarriorClone()
        {
            var StartGeralt = new Warrior();
            Console.WriteLine(StartGeralt);

            var sklonowanyGeralt = StartGeralt.Clone();
            Console.WriteLine(sklonowanyGeralt);

        }

    }
}
