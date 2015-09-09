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

        [TestMethod]
        public void ShowEquipment1()
        {
            new OracleDiceProvider().Add(1, 4).Build();
            Mag magiczny1 = new Mag() { Capacity = 300000, CapacityNow = 300000 };
            List<Money> moneyList = new List<Money>();
            moneyList.AddRange(Enumerable.Range(1, 23).Select(x => new Money()));
            
            List<Item> itemList = new List<Item>();
            itemList.AddRange(
                Enumerable.Range(1, 12).Select(x =>
                    new Armour()
                        {
                            Name = "zbroja" + (23 - x).ToString(),
                            Price = x,
                            Weight = (23 - x%6),
                            Defense = x
                        }

            ));
            //itemList.AddRange(
            //    Enumerable.Range(1, 23).Select(x =>
            //        new Helmet()
            //            {
            //                Name = "helm" + x.ToString(),
            //                Price = x,
            //                Weight = x,
            //                Defense = x
            //            }
            //));
            //itemList.AddRange(
            //    Enumerable.Range(1, 23).Select(x =>
            //        new MagicWeapon()
            //            {
            //                Name = "miecz" + x.ToString(),
            //                Price = x,
            //                Weight = x,
            //                Attack = x
            //            }
            //));

            itemList.ForEach(x => magiczny1.AddItem(x));
            Console.WriteLine(magiczny1.ShowEquipment());

            Console.WriteLine(magiczny1.ShowEquipment("Name"));
            Console.WriteLine(magiczny1.ShowEquipment("Weight"));

            Console.WriteLine(magiczny1.ShowEquipment("Price"));
        }
    }
}
