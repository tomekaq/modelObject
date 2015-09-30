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
        public void ShowInfoAboutArmour()
        {
            Armour armour = new Armour()
            {
                Weight = 500,
                Name = "zbroja",
                Price = 32212
            };

            Console.WriteLine(armour.ToString());
        }

        [TestMethod]
        public void ShowInfoAboutHelmet()
        {
            Helmet helmet = new Helmet()
            {
                Weight = 500,
                Name = "helm",
                Price = 32212
            };

            Console.WriteLine(helmet.ToString());
        }

        [TestMethod]
        public void ShowInfoAboutShield()
        {
            Shield shield = new Shield()
            {
                Weight = 500,
                Name = "tarcza",
                Price = 32212
            };

            Console.WriteLine(shield.ToString());
        }

        [TestMethod]
        public void ShowInfoAboutTrousers()
        {
            Trousers trousers = new Trousers()
            {
                Weight = 500,
                Name = "spodnie",
                Price = 32212
            };

            Console.WriteLine(trousers.ToString());
        }

        [TestMethod]
        public void ShowInfoAboutSword()
        {
            Weapon sword = new Weapon()
            {
                Attack = 23,
                Weight = 500,
                Name = "miecz",
                Price = 32212
            };

            Console.WriteLine(sword.ToString());
        }

        [TestMethod]
        public void ShowEquipment1()
        {
            new OracleDiceProvider().Add(1, 4).Build();
            Mag magiczny1 = new Mag() { Capacity = 300000, CapacityNow = 300000 };
            List<Money> moneyList = new List<Money>();
            moneyList.AddRange(Enumerable.Range(1, 15).Select(x => new Money()));

            List<Item> itemList = new List<Item>();
            itemList.AddRange(
                Enumerable.Range(1, 12).Select(x =>
                    new Armour()
                        {
                            Name = "zbroja" + (23 - x).ToString(),
                            Price = x,
                            Weight = (23 - x % 6),
                            Defense = x
                        }
            ));

            itemList.AddRange(
                Enumerable.Range(1, 15).Select(x =>
                    new Helmet()
                        {
                            Name = "helm " + x.ToString(),
                            Price = x,
                            Weight = 15 - x,
                            Defense = x
                        }
            ));

            itemList.ForEach(x => magiczny1.AddItem(x));
            Console.WriteLine("Posortowane po nazwie");
            Console.WriteLine(magiczny1.ShowEquipment("Name"));
            Console.WriteLine("Posortowane po wadze");
            Console.WriteLine(magiczny1.ShowEquipment("Weight"));
            Console.WriteLine("Posortowane po cenie");
            Console.WriteLine(magiczny1.ShowEquipment("Price"));
        }
    }
}
