using ModelingObjectTask.Items;
using System;

namespace ModelingObjectTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Warrior() { HealthPoints = 200 };
            var b = new Mag();
            var c = new Mag() { Name = "Nowy",Strength = 5 };
            var d = new Warrior() { Name = "Szałowy" };
         
            d.ChangeHealth(-1900);
            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
            Console.WriteLine(c.ToString());

            Console.WriteLine(d.ToString());


            d.ChangeHealth(-1);
            Console.WriteLine(a.ToString());
            Console.WriteLine(d.ToString());
            var druzynaPierscienia = new Squad() { Name = "Druzyna pierścienia" };
            
            druzynaPierscienia.DodajPostac(a);
            druzynaPierscienia.DodajPostac(b);
            druzynaPierscienia.DodajPostac(c);
            druzynaPierscienia.DodajPostac(d);

            var moneta = new Money() { Name = "talary" };
        

            Console.WriteLine(druzynaPierscienia[2].ToString());

            var e = new Warrior() { Name = "Hulk"  };

            var sklonowanyGerald = druzynaPierscienia.CloneHero(0);

            var przykladowy = druzynaPierscienia[2];
            var hipermiecz = new Weapon();
            hipermiecz.Name = "hiper miecz";
            hipermiecz.Attack = 32;

            przykladowy.prawaReka.Item =hipermiecz;
            
            Console.WriteLine(" ");
            Console.WriteLine(sklonowanyGerald.ToString());
            

            Console.WriteLine(" ");

            Console.WriteLine(" ");
            Console.WriteLine(druzynaPierscienia.ToString());

            var nowaDruzyna = druzynaPierscienia.Clone();

            Console.WriteLine("Nowa");
            Console.WriteLine(nowaDruzyna.ToString());

            Console.ReadLine();

        }
    }
}
