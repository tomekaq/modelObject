using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelingObjectTask;
using ModelingObjectTask.Items;
using ModelingObjectTask.BodyParts;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class MagTest1
    {
        [TestMethod]
        public void MagParametr()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            var Xardas = new Mag() 
            {
                HealthPoints = 10000,
                HealthPointsNow = 10000 
            };
            new OracleDiceProvider().Add(1).Build();

            Console.WriteLine(Xardas);
            Xardas.Agility = 34;
            Console.WriteLine("Mag Agility: {0}", Xardas.Agility);
  
            //Xardas.DefensePoint = 342;
            Console.WriteLine("Mag DefensePoint: {0}", Xardas.DefensePoint);

            Console.WriteLine("Mag HealthPoints: {0}", Xardas.HealthPoints);
            Console.WriteLine("Mag HealthPointsNow: {0}", Xardas.HealthPointsNow);

            Xardas.HealthPointsNow -= 199;
            Console.WriteLine("Mag HealthPointsNow: {0}", Xardas.HealthPointsNow);

            Xardas.ChangeHealth(-1);
            Console.WriteLine("Mag HealthPointsNow: {0}", Xardas.HealthPointsNow);
            Console.WriteLine("Mag is Alive ?: {0}", Xardas.IsAlive);

            Xardas.MoneyAmount = 32;
            Console.WriteLine("Mag MoneyAmount: {0}", Xardas.MoneyAmount);

            Xardas.Name = "Sinowłosy";
            Console.WriteLine("Mag Name: {0}", Xardas.Name);

            Xardas.Name += "34";
            Console.WriteLine("Mag Name: {0}", Xardas.Name);
        }

        [TestMethod]
        public void MagWearMagicWeapon()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 30
            };

            Mag magiczny = new Mag() { 
            Name = "magiczny"};

            new OracleDiceProvider().Add(1).Add(1).Add(1).Build();

            Console.WriteLine("{0} bez broni {1}",magiczny.Name,magiczny.AttackValue());

            magiczny.leftHand.PutOn(superrozdzka);
     //       magiczny.leftHand.PutOn(superrozdzka);

            Console.WriteLine("{0} z bronia w lewej rece {1}", magiczny.Name, magiczny.AttackValue());


            magiczny.rightHand.PutOn(superrozdzka);

            Console.WriteLine("{0} w obu rękach {1}", magiczny.Name, magiczny.AttackValue());
        }

        [TestMethod]
        public void WizzardDefenseShouldBeRelatedToWearedItems()
        {
            //given
            Armour superzbroja = new Armour()
            {
                Defense = 20
            };
            Helmet superhelm = new Helmet()
            {
                Name = "super Hełm",
                Defense = 20
            };

            Shield superTarcza = new Shield()
            {
                Defense = 20
            };
            Trousers jeansy = new Trousers()
            {
                Defense = 20
            };
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Mag magiczny = new Mag();

            //when

            new OracleDiceProvider().Add(1).Add(1).Build();
            var defValue = magiczny.DefenseValue();

            magiczny.head.PutOn(superhelm);
            magiczny.legs.PutOn(jeansy);
            magiczny.leftHand.PutOn(superTarcza);
            magiczny.body.PutOn(superzbroja);

            var fullArmorDefValue = magiczny.DefenseValue();
            
            //then
            Assert.IsTrue(defValue < fullArmorDefValue, "Defense value should be greater when you wear something");
        }

        [TestMethod]
        public void WizzardFirstPutOn()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Mag magiczny = new Mag();
            Armour superzbroja = new Armour()
            {
                Defense = 20
            };

            magiczny.body.PutOn(superzbroja);
         
            Assert.AreEqual(magiczny.body.Clothes.FirstOrDefault(), superzbroja);
            //Character should wear something he put on
        }

        [TestMethod]
        public void WizzardNextPutOn()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Mag magiczny = new Mag();
            Armour superzbroja1 = new Armour()
            {
                Defense = 20
            };
            Armour superzbroja2 = new Armour()
            {
                Defense = 20
            };
            Armour superzbroja3 = new Armour()
            {
                Defense = 20
            };

           
            magiczny.body.PutOn(superzbroja3);

            Assert.AreEqual(magiczny.body.Clothes.FirstOrDefault(), superzbroja3);
            //Character should wear something he put on
        }


        [TestMethod]
        public void MagChangeWeapon()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Mag magiczny = new Mag();

            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Name = "super rozdzka",
                Attack = 1
            };

            magiczny.leftHand.PutOn(superrozdzka);
          
            new OracleDiceProvider().Add(1).Add(1).Build();

            var goodAttack = magiczny.AttackValue();

            MagicWeapon zlarozdzka = new MagicWeapon()
            {
                Attack =0
            };

            magiczny.leftHand.PutOn(zlarozdzka);
            var badAttack = magiczny.AttackValue();
            
            Assert.IsTrue(goodAttack > badAttack, "Attack with better weapon is greater");
            
           
        }
        
        [TestMethod]
        public void MagTryUseWeaponInLeftHand()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Mag magiczny = new Mag() {

                leftHand = new ModelingObjectTask.BodyParts.LeftHand()
                {
                    Health = 0
                }
            };

            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

           var AttackWithoutWeapon =  magiczny.AttackValue();
           var DefenseWithoutWeapon = magiczny.DefenseValue();

            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 22,
                Defense =200
            };

            magiczny.leftHand.PutOn(superrozdzka);

            var AttackWithWeapon = magiczny.AttackValue();
            var DefenseWithWeapon = magiczny.DefenseValue();

            Assert.IsTrue(AttackWithoutWeapon == AttackWithWeapon,"Attack with Weapon is greater");
            Assert.IsTrue(DefenseWithoutWeapon == DefenseWithWeapon, "Defense with Weapon is greater");
        }

        [TestMethod]
        public void MagTryUseWeaponInRightHand()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Mag magiczny1 = new Mag()
            {
                rightHand = new RightHand()
                {
                    Health = 0
                }
            };
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            var AttackWithoutWeapon = magiczny1.AttackValue();
            var DefenseWithoutWeapon = magiczny1.DefenseValue();

            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 22,
                Defense = 200
            };

            magiczny1.rightHand.PutOn(superrozdzka);

            var AttackWithWeapon = magiczny1.AttackValue();
            var DefenseWithWeapon = magiczny1.DefenseValue();

            Assert.IsTrue(AttackWithoutWeapon == AttackWithWeapon, "Attack with Weapon is the same");
            Assert.IsTrue(DefenseWithoutWeapon == DefenseWithWeapon, "Defense with Weapon is the same");
        }

        [TestMethod]
        public void MagHasDeadHead() {

            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Mag magiczny = new Mag()
            {
                head = new Head 
                {
                    Health = 0
                }

            };
          //  Assert.AreEqual(false,magiczny.IsAlive);
        }

        [TestMethod]
        public void MagHasDeadBody()
        {
            new OracleDiceProvider().Add(1).Add(1).Add(1).Add(1).Build();

            Mag magiczny = new Mag()
            {
                body = new Body
                {
                    Health = 0
                }

            };
            //Assert.AreEqual(false, magiczny.IsAlive);
        }
    }
}



