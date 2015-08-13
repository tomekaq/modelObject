using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelingObjectTask
{
    public abstract class Hero
    {
        public string Imie { get; set; }
        public int Sila { get; set; }
        public decimal Zywotnosc { get; set; }
        public int PktZycia { get; set; }
        public int PktZyciaAktualnie { get; set; }
        public int Zrecznosc { get; set; }

        //ekwipunek
        //cena 
        //waga
        //kategoria
        //przedmiot moze dawac modyfikatory
        // wyliczalne pkt ataku zalezne od sily i atrybutow przedmiotow
        // przy kazdym ataku losowany pkt ataku
        // wspolczynnik decydujacy o trafieniu zręczność

        // atak na przeciwnika to roznica miedzy wlasna a przeciwnika
        // i dopiero wtedy losowanie ile ataku 


        public decimal ZmienZywotnosc(int strata)
        {
            if (PktZyciaAktualnie - strata < 0)
                Zywotnosc = 0;
            if (PktZycia - (PktZyciaAktualnie + strata) < 0)
                Zywotnosc = 100;

            PktZyciaAktualnie += strata;
            Zywotnosc = (decimal) PktZyciaAktualnie / PktZycia * 100;
            return Zywotnosc;
        }
        public abstract decimal MocAtaku();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Imię: {0} ", Imie);
            sb.AppendFormat("Żywotność: {0}% ", Zywotnosc);
            sb.AppendFormat("Zręczność: {0} ", Zrecznosc);
            sb.AppendFormat("Wartość Ataku: {0} ", MocAtaku());
            return sb.ToString();
        }
    }

    public class Mag : Hero
    {
        public int PunktyMagii { get; set; }

        public Mag()
        {
            Imie = "Xardas";
            Zywotnosc = 100;
            PktZycia = 1000;
            PktZyciaAktualnie = PktZycia;
            Sila = new Random().Next(1, 6);
            PunktyMagii = new Random().Next(2, 12);
            Zrecznosc = new Random().Next(2, 12);
        }

        public override decimal MocAtaku()
        {
            return (PunktyMagii + Sila) * PktZyciaAktualnie;
        }
    }

    public class Wojownik : Hero
    {
        public Wojownik()
        {
            Imie = "Geralt";
            Zywotnosc = 100;
            PktZycia = 2000;
            PktZyciaAktualnie = PktZycia;
            Sila = new Random().Next(3, 18);
            Zrecznosc = new Random().Next(2, 12);
        }

        public override decimal MocAtaku()
        {
            if (Zywotnosc < 5 && Zywotnosc > 0)
                return Sila * 100;
            return Sila * PktZyciaAktualnie;
        }
    }

    class Druzyna : ICloneable
    {
        public string Nazwa { get; set; }
        List<Hero> druzynaPostaci = new List<Hero>();

        public object Clone()
        {
            return this.MemberwiseClone();
        }

     //   public object KopiaBohatera(int index)
     //   {
     //       Assembly d = Assembly.GetExecutingAssembly();
     //       Type t = druzynaPostaci[index].GetType();
     //       var fgfg = (t.Name.GetType());
     //       Type[] argument = Type.EmptyTypes;
     //       ConstructorInfo heroConstructor = t.GetConstructor(argument);
     //    //   object temp = heroConstructor.Invoke(new[] { druzynaPostaci[index].Imie, druzynaPostaci[index].Sila,
     ////           druzynaPostaci[index].Zywotnosc });
     //       return null;
     //   }

        public void DodajPostac(Hero hero)
        {
            druzynaPostaci.Add(hero);
        }

        public Hero this[int index]
        {
            get
            {
                return druzynaPostaci[index];
            }
            set
            {
                druzynaPostaci[index] = value;
            }
        }

        public decimal AtakDruzyny()
        {
            return druzynaPostaci.Select(x => x.MocAtaku()).Sum();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
           
            sb.AppendFormat("Nazwa: {0} ", Nazwa);
            sb.AppendFormat("Wartość ataku drużyny: {0} ", AtakDruzyny());
            sb.AppendFormat("Lista postaci: \n");
            druzynaPostaci.Select(x => sb.AppendFormat("{0} \n", x)).ToList();
        
            return sb.ToString();
        }
    }

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
            druzynaPierscienia[3] = e;
            e.ZmienZywotnosc(-34);
            e.ZmienZywotnosc(-34);
            e.ZmienZywotnosc(-34);

            Wojownik fd = new Wojownik() { };

            var f = new Mag() { Imie = "Nowy Mag", PunktyMagii = 12};
            Console.WriteLine(f.ToString());

            Console.WriteLine(" ");
            Console.WriteLine(druzynaPierscienia[3].ToString());

            //var sklonowanyGerald = druzynaPierscienia.KopiaBohatera(0);
            //Console.WriteLine(" ");
            //Console.WriteLine(sklonowanyGerald.ToString());

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
