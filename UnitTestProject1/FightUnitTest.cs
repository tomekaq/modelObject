using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelingObjectTask;
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
        [TestMethod()]
        public void WarriorAttackMag()
        {
            var Geralt = new Warrior() { HealthPoints = 100, HealthPointsNow = 100 };
            var Xardas = new Mag() { HealthPoints = 100, HealthPointsNow = 100 };

            Console.WriteLine(Geralt.ToString());


            Console.WriteLine(Xardas.ToString());

        }
    }
}
