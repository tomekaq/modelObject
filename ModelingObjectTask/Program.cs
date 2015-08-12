using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingObjectTask
{
    abstract class Hero
    {
        internal string Imie { get; set; }
        internal int Sila { get; set; }
        internal decimal Zywotnosc { get; set; }

        public decimal ZmienZywotnosc(decimal strata)
        {
            if (Zywotnosc - strata < 0)
                Zywotnosc = 0;
            else if (Zywotnosc + strata > 100)
                Zywotnosc = 100;
            else
                Zywotnosc += strata;
            return Zywotnosc;
        }
        public abstract decimal MocAtaku();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Imię: {0} ", Imie);
            sb.AppendFormat("Żywotność: {0} ", Zywotnosc);
            sb.AppendFormat("Wartość Ataku: {0} ", MocAtaku());
            return sb.ToString();
        }
    }

    class Mag : Hero
    {
        public int PunktyMagii { get; set; }

        public Mag()
        {
            Imie = "Xardas";
            Zywotnosc = 100;
            Sila = new Random().Next(1, 6);
            PunktyMagii = new Random().Next(2, 12);
        }

        public override decimal MocAtaku()
        {
            return (PunktyMagii + Sila) * Zywotnosc;
        }
    }

    class Wojownik : Hero
    {
        public Wojownik()
        {
            Imie = "Geralt";
            Zywotnosc = 100;
            Sila = new Random().Next(3, 18);
        }

        public override decimal MocAtaku()
        {
            if (Zywotnosc < 5 && Zywotnosc > 0)
                return Sila * 100;
            return Sila * Zywotnosc;
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
            druzynaPostaci.Select(x => x.ToString()).Select(x => sb.AppendFormat("{0}  \n", x)).ToList();
        
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

            var e = new Wojownik() { Imie = "Hulk" };
            druzynaPierscienia[3] = e;
            e.ZmienZywotnosc(-34);

            druzynaPierscienia[2].Imie = "Mariola";

            var f = new Mag() { Imie = "Nowy Mag", PunktyMagii = 12};
            Console.WriteLine(f.ToString());

            Console.WriteLine(" ");
            Console.WriteLine(druzynaPierscienia[3].ToString());

            Console.WriteLine(" ");
            Console.WriteLine(druzynaPierscienia.ToString());

            var nowaDruzyna = druzynaPierscienia.Clone();

            Console.WriteLine("Nowa");
            Console.WriteLine(nowaDruzyna.ToString());

            Console.ReadLine();

        }
    }
}
