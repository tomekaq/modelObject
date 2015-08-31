using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelingObjectTask;
using ModelingObjectTask.BodyParts;
using ModelingObjectTask.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject1
{

    [TestClass]
    public class FightUnitTest
    {

        [TestMethod]
        public void WizzardAttackWarrior()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();
            Warrior Geralt = new Warrior()
            {
                HealthPoints = 1000,
                HealthPointsNow = 1000
            };

            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            var inputCapacity = 40;
            var inputHealthPoints = 1000;

            var Xardas = new Mag()
            {
                Capacity = inputCapacity,
                HealthPoints = inputHealthPoints,
                HealthPointsNow = inputHealthPoints
            };

            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 10
            };

            var XardasHealthBefore = Xardas.HealthPointsNow;
            var GeraltHealthBefore = Geralt.HealthPointsNow;

            Xardas.AddItem(superrozdzka);
            Xardas.PutOnBodyPart(superrozdzka, Xardas.rightHand);



            new OracleDiceProvider().Add(100) // myAttack
                        .Add(1) // enemyDefense
                        .Add(100)  // myHit
                        .Add(1)  // enemyHit
                        .Add(1)  // drawAttack
                        .Add(1)  // body
                        .Add(1)  // head
                        .Add(1)  // leftHand
                        .Add(1)  // rightHand
                        .Add(1)  // legs
                        .Build();

            Xardas.Attack(Geralt);

            var XardasHealthAfter = Xardas.HealthPointsNow;
            var GeraltHealthAfter = Geralt.HealthPointsNow;

            Assert.IsTrue(XardasHealthBefore == XardasHealthAfter, "Wizzard Health Points have not changed");
            Assert.IsTrue(GeraltHealthBefore > GeraltHealthAfter, "Warrior Points have less");

        }

        [TestMethod]
        public void WizzardAttackWarriorCounterAttack()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();
            Warrior Geralt = new Warrior()
            {
                HealthPoints = 1000,
                HealthPointsNow = 1000
            };

            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            var inputCapacity = 40;
            var inputHealthPoints = 1000;

            var Xardas = new Mag()
            {
                Capacity = inputCapacity,
                HealthPoints = inputHealthPoints,
                HealthPointsNow = inputHealthPoints
            };

            var XardasHealthBefore = Xardas.HealthPointsNow;
            var GeraltHealthBefore = Geralt.HealthPointsNow;

            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 2
            };

            Weapon superNierozdzka = new Weapon()
            {
                Attack = 233
            };

            Xardas.AddItem(superrozdzka);
            Xardas.PutOnBodyPart(superrozdzka, Xardas.rightHand);

            Geralt.AddItem(superNierozdzka);
            Geralt.PutOnBodyPart(superNierozdzka, Geralt.rightHand);

            new OracleDiceProvider().Add(1) // myAttack
                                    .Add(100) // enemyDefense
                                    .Add(1)  // myHit
                                    .Add(1)  // enemyHit
                                    .Add(2)  // myHitDefense
                                    .Add(500) //enemyHit
                                    .Add(3)  // myHitDefenseSecond
                                    .Add(1)  // drawAttack
                                    .Add(1)  // body
                                    .Add(1)  // head
                                    .Add(1)  // leftHand
                                    .Add(1)  // rightHand
                                    .Add(1)  // legs
                                    .Build();
            Xardas.Attack(Geralt);

            var XardasHealthAfter = Xardas.HealthPointsNow;
            var GeraltHealthAfter = Geralt.HealthPointsNow;

            Assert.IsTrue(XardasHealthBefore > XardasHealthAfter, "Wizzard Health Points have less");
            Assert.IsTrue(GeraltHealthBefore == GeraltHealthAfter, "Warrior Points have not changed");
        }

        [TestMethod]
        public void WizzardFightToDeath()
        {
            OracleDiceProvider.Reset();
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
                Attack = 50
            };

            Weapon supermieczor = new Weapon()
            {
                Attack = 50
            };


            Xardas.AddItem(superrozdzka);
            Xardas.PutOnBodyPart(superrozdzka, Xardas.rightHand);

            Geralt.AddItem(supermieczor);
            Geralt.PutOnBodyPart(supermieczor, Geralt.rightHand);
            int i = 0;
            while (Xardas.IsAlive && Geralt.IsAlive)
            {
                Xardas.Attack(Geralt);
                if ((Xardas.IsAlive && Geralt.IsAlive))
                    Geralt.Attack(Xardas);
                i++;
            }

            var XardasHealthAfter = Xardas.HealthPointsNow;
            var GeraltHealthAfter = Geralt.HealthPointsNow;
            Console.WriteLine("i {0}", i);

            Console.WriteLine("Xardas is alive? {0}", Xardas.IsAlive);
            Console.WriteLine("Xardas health {0}", Xardas.HealthPointsNow);

            Xardas.bodyPart.ForEach(x => Console.WriteLine("{0} ,             {1} ,      {2}", x.GetType().Name, x.Alive, x.Health));

            Console.WriteLine("Geralt is alive? {0}", Geralt.IsAlive);
            Console.WriteLine("Geralt health {0}", Geralt.HealthPointsNow);
            Geralt.bodyPart.ForEach(x => Console.WriteLine("{0} ,             {1} ,      {2}", x.GetType().Name, x.Alive, x.Health));

            Assert.IsTrue(Xardas.IsAlive ^ Geralt.IsAlive, "There can be only one survivor");

        }

        [TestMethod]
        public void WizzardAttackWarriorDefense()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();
            Warrior Geralt = new Warrior()
            {
                HealthPoints = 1000,
                HealthPointsNow = 1000
            };

            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            var inputCapacity = 40;
            var inputHealthPoints = 1000;

            var Xardas = new Mag()
            {
                Capacity = inputCapacity,
                HealthPoints = inputHealthPoints,
                HealthPointsNow = inputHealthPoints
            };

            var XardasHealthBefore = Xardas.HealthPointsNow;
            var GeraltHealthBefore = Geralt.HealthPointsNow;
            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 1
            };

            Xardas.AddItem(superrozdzka);
            Xardas.PutOnBodyPart(superrozdzka, Xardas.rightHand);

            new OracleDiceProvider()
                    .Add(1) // myAttack
                    .Add(50)// enemy Defense
                    .Add(1) // myHit
                    .Add(1) // enemyHit
                    .Add(1) // enemyAttack
                    .Add(1) // myDefense
                    .Add(0) // enemyHit
                    .Add(10) // myHit
                    .Build();
            Xardas.Attack(Geralt);

            var XardasHealthAfter = Xardas.HealthPointsNow;
            var GeraltHealthAfter = Geralt.HealthPointsNow;

            Assert.IsTrue(XardasHealthBefore == XardasHealthAfter, "Wizzard Health Points have not changed");
            Assert.IsTrue(GeraltHealthBefore == GeraltHealthAfter, "Warrior Points have not changed");
        }
    }
}
