﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

   //    [TestMethod]
        public void ShowEquipment()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();
            Mag magiczny1 = new Mag() { Capacity = 3000 };
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

            itemList.Add(new Money() { Name = "moneta" });
            itemList.Add(new Armour() { Name = "rozdzka" + 24 });

            itemList.ForEach(x => magiczny1.AddItem(x));

            var t = magiczny1.ShowEquipment();
            Console.WriteLine("{0}", t);

           // magiczny1.equipment.ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
