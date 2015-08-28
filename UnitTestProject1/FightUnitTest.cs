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
                Attack = 2
            };
            
            var XardasHealthBefore = Xardas.HealthPointsNow;
            var GeraltHealthBefore = Geralt.HealthPointsNow;

            Xardas.rightHand.PutOn(superrozdzka);

            new OracleDiceProvider().Add(1).Add(40).Add(1).Add(2).Add(3).Add(4).Add(5).Add(6)
                                    .Add(7).Add(8).Add(1).Add(1).Build();
            Xardas.Attack(Geralt);

            var XardasHealthAfter = Xardas.HealthPointsNow;
            var GeraltHealthAfter = Geralt.HealthPointsNow;

            Assert.IsTrue(XardasHealthBefore == XardasHealthAfter, "Wizzard Health Points have not changed");
            Assert.IsTrue(GeraltHealthBefore > GeraltHealthAfter, "Warrior Points have less");

        }

        [TestMethod]
        public void WizzardAttackWarriorCounterAttack ()
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

            Xardas.rightHand.PutOn(superrozdzka);
            Geralt.rightHand.PutOn(superNierozdzka);

            new OracleDiceProvider().Add(911)// enemyDefense
                                    .Add(4)  // myHit
                                    .Add(1)  // enemyHit
                                    .Add(2)  //myHitDefense
                                    .Add(3)  //myHitDefenseSecond
                                    .Add(43) //enemyHit
                                    .Add(1)  // drawAttack
                                    .Add(1)
                                    .Add(2)
                                    .Add(3)
                                    .Add(4)
                                    .Add(5).Build();
            Xardas.Attack(Geralt);

            var XardasHealthAfter = Xardas.HealthPointsNow;
            var GeraltHealthAfter = Geralt.HealthPointsNow;
            
            Assert.IsTrue(XardasHealthBefore > XardasHealthAfter, "Wizzard Health Points have less");
            Assert.IsTrue(GeraltHealthBefore == GeraltHealthAfter, "Warrior Points have not changed");

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

            Xardas.rightHand.PutOn(superrozdzka);

            new OracleDiceProvider().Add(1).Add(4).Add(4).Add(1).Add(1).Add(1).Build();
            Xardas.Attack(Geralt);

            var XardasHealthAfter = Xardas.HealthPointsNow;
            var GeraltHealthAfter = Geralt.HealthPointsNow;
            
            Assert.IsTrue(XardasHealthBefore == XardasHealthAfter, "Wizzard Health Points have not changed");
            Assert.IsTrue(GeraltHealthBefore == GeraltHealthAfter, "Warrior Points have not changed");
        }
    }
}
