using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelingObjectTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Wojownik();
            Console.WriteLine(a.ToString());

            var b = new Mag();
            Console.WriteLine(b.ToString());

            var c = new Mag() { Imie = "Nowy",Sila = 5 };

            Console.WriteLine(c.ToString());

            var d = new Wojownik() { Imie = "Szałowy" };
         
            d.ZmienZywotnosc(-97);

            Console.WriteLine(d.ToString());

            var druzynaPierscienia = new Druzyna() { Nazwa = "Druzyna pierścienia" };
            
            druzynaPierscienia.DodajPostac(a);
            druzynaPierscienia.DodajPostac(b);
            druzynaPierscienia.DodajPostac(c);
            druzynaPierscienia.DodajPostac(d);

            Console.WriteLine(druzynaPierscienia[2].ToString());



            var e = new Wojownik() { Imie = "Hulk"  };

            //Console.WriteLine(" ");
            //druzynaPierscienia[3] = e;
            //Console.WriteLine(druzynaPierscienia[3].ToString());

            //druzynaPierscienia[3] = e;
            //e.ZmienZywotnosc(-364);
            //e.ZmienZywotnosc(-364);
            //e.ZmienZywotnosc(-361);

            //Console.WriteLine(" ");
            //Console.WriteLine(druzynaPierscienia[3].ToString());

            var sklonowanyGerald = druzynaPierscienia.KopiaBohatera(0);

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
