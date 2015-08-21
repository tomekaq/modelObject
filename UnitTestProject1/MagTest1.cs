using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelingObjectTask;
using ModelingObjectTask.Items;

namespace UnitTestProject1
{
    [TestClass]
    public class MagTest1
    {
        [TestMethod]
        public void MagParametr()
        {
            var Xardas = new Mag(){HealthPoints = 10000};

            Console.WriteLine(Xardas);
            Xardas.Agility = 34;
            Console.WriteLine("Warrior Agility: {0}", Xardas.Agility);

            //Xardas.DefensePoint = 342;
            Console.WriteLine("Warrior DefensePoint: {0}", Xardas.DefensePoint);

            Console.WriteLine("Warrior HealthPoints: {0}", Xardas.HealthPoints);
            Console.WriteLine("Warrior HealthPointsNow: {0}", Xardas.HealthPointsNow);

            Xardas.HealthPointsNow -= 199;
            Console.WriteLine("Warrior HealthPointsNow: {0}", Xardas.HealthPointsNow);

            Xardas.ChangeHealth(-1);
            Console.WriteLine("Warrior HealthPointsNow: {0}", Xardas.HealthPointsNow);
            Console.WriteLine("Warrior is Alive ?: {0}", Xardas.IsAlive);

            Xardas.MoneyAmount = 32;
            Console.WriteLine("Warrior MoneyAmount: {0}", Xardas.MoneyAmount);

            Xardas.Name = "Sinowłosy";
            Console.WriteLine("Warrior Name: {0}", Xardas);

            Xardas.Name += "34";
            Console.WriteLine("Warrior Name: {0}", Xardas);
        }

        [TestMethod]
        public void MagWearMagicWeapon()
        {
            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 22
            };
            Mag magiczny = new Mag() { 
            Name = "magiczny"};

            Console.WriteLine("{0} bez broni {1}",magiczny.Name,magiczny.AttackValue());

            magiczny.leftHand.PutOn(superrozdzka);
            magiczny.leftHand.PutOn(superrozdzka);

            Console.WriteLine("{0} z bronia w lewej rece {1}", magiczny.Name, magiczny.AttackValue());


            magiczny.rightHand.PutOn(superrozdzka);

            Console.WriteLine("{0} w obu rękach {1}", magiczny.Name, magiczny.AttackValue());
        }


        [TestMethod]
        public void MagWearFullArmour()
        {
            Armour superzbroja = new Armour()
            {
                Defense = 10
            };
            Helmet superhelm = new Helmet()
            {
                Name = "super Hełm",
                   Defense = 10
            };

            Shield superTarcza = new Shield()
            {
                Defense = 10
            };
            Trousers jeansy = new Trousers()
            {
                Defense = 10
            };

            Mag magiczny = new Mag();

            Console.WriteLine("{0} bez zbroji {1}",magiczny.Name,magiczny.DefenseValue());

            magiczny.head.PutOn(superhelm);
            magiczny.legs.PutOn(jeansy);
            magiczny.leftHand.PutOn(superTarcza);
            magiczny.body.PutOn(superzbroja);

            Console.WriteLine("{0} z zalozona zbroja {1}", magiczny.Name, magiczny.DefenseValue());

        }
        [TestMethod]
        public void MagDrinkHealthPotion()
        {
            Mag magiczny = new Mag();
            
        }

        [TestMethod]
        public void MagChangeWeapon()
        {
            Mag magiczny = new Mag();

            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 22
            };

            magiczny.leftHand.PutOn(superrozdzka);
            Console.WriteLine("{0} z dobra bronia {1}", magiczny.Name, magiczny.AttackValue());

            MagicWeapon zlarozdzka = new MagicWeapon()
            {
                Attack =0
            };

            magiczny.leftHand.PutOn(zlarozdzka);

            Console.WriteLine("{0} z zla bronia {1}", magiczny.Name, magiczny.AttackValue());

        }
        [TestMethod]
        public void MagTryUseWeaponInLeftHand()
        {
            Mag magiczny = new Mag() {

                leftHand = new ModelingObjectTask.BodyParts.LeftHand()
                {
                    Health = 0
                }
            };
            Console.WriteLine("Atak {0} bez broni: {1}", magiczny.Name, magiczny.AttackValue());
            Console.WriteLine("Obrona {0} bez bronia: {1}", magiczny.Name, magiczny.DefenseValue());
            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 22,
                Defense =200
            };

            magiczny.leftHand.PutOn(superrozdzka);

            Console.WriteLine("Atak {0} z bronia: {1}", magiczny.Name, magiczny.AttackValue());
            Console.WriteLine("Obrona {0} z bronia: {1}", magiczny.Name, magiczny.DefenseValue());
        
        }
        public void MagTryUseWeaponInRightHand()
        {
            Mag magiczny = new Mag()
            {
                rightHand = new ModelingObjectTask.BodyParts.RightHand()
                {
                    Health = 0
                }
            };

            Console.WriteLine("Atak {0} bez broni: {1}", magiczny.Name, magiczny.AttackValue());
            Console.WriteLine("Obrona {0} bez bronia: {1}", magiczny.Name, magiczny.DefenseValue());
            MagicWeapon superrozdzka = new MagicWeapon()
            {
                Attack = 22,
                Defense = 200
            };

            magiczny.rightHand.PutOn(superrozdzka);

            Console.WriteLine("Atak {0} z bronia: {1}", magiczny.Name, magiczny.AttackValue());
            Console.WriteLine("Obrona {0} z bronia: {1}", magiczny.Name, magiczny.DefenseValue());

        }
    }
}



