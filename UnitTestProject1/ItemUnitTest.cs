using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelingObjectTask.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class ItemUnitTest
    {
        [TestMethod]
        public void CreateItem()
        {
            var superArmour = new Armour() 
            {
                Name = "Super Zbroja",
                Defense = 32,
                Price = 21,
                Weight = 100
            };

            var zlyArmour = new Armour() { 
                Name = "Zly Armour",
                Weight = -1,
                Price = -12,
                Defense = -2
            };
        }
    }
}
