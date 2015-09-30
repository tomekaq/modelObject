using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelingObjectTask;
using ModelingObjectTask.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class ShowInfoUnitTest
    {
        [TestMethod]
        public void WarriorInfo()
        {
            OracleDiceProvider.Reset();

            Warrior Geralt = new Warrior()
            {
                Name = "Biały Wilk",
                Capacity = 40,
                CapacityNow = 40,
                HealthPoints = 1000,
                HealthPointsNow = 1000
            };
            List<Money> moneyList = new List<Money>();
            moneyList.AddRange(Enumerable.Range(1, 32).Select(x => new Money()));
            moneyList.ForEach(x => Geralt.AddItem(x));

            Console.WriteLine(Geralt.ToString());
        }
    }
}
