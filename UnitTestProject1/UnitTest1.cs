﻿using System;
using ModelingObjectTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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



    }
}