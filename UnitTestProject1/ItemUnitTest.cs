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
    public class ItemUnitTest
    {

       // [TestMethod]
        public void ShowEquipment()
        {
            Mag magiczny1 = new Mag() { Capacity = 3000};

            List<Money> moneyList = new List<Money>();
            moneyList.AddRange(Enumerable.Range(1, 23).Select(x => new Money()));
            List<Item> itemList = new List<Item>();
            itemList.AddRange(
                Enumerable.Range(1, 23).Select(x =>

               new Armour()
                {
                    Name = "rozdzka" + x.ToString(),
                    
                }

            ));
            itemList.ForEach(x =>  magiczny1.AddItem(x) );


            var t = magiczny1.ShowEquipment();
            Console.WriteLine( "{0}" , t);
        }
    }
}
