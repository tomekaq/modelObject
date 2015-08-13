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
        public List<Przedmiot> ekwipunek = new List<Przedmiot>();

        public void ZmienZywotnosc(int strata)
        {
            if (this.PktZyciaAktualnie - strata < 0)
                this.PktZyciaAktualnie = 0;
            else if ((this.PktZyciaAktualnie + strata) - this.PktZycia > 100)
                this.PktZyciaAktualnie = this.PktZycia;
            else
                this.PktZyciaAktualnie += strata;
        }
        public abstract decimal MocAtaku();

        public void DodajPrzedmiot(Przedmiot przedmiot){

            ekwipunek.Add(przedmiot);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Imię: {0} ", this.Imie);
            sb.AppendFormat("Żywotność: {0}% ", (decimal)this.PktZyciaAktualnie/this.PktZycia*100);
            sb.AppendFormat("Zręczność: {0} ", this.Zrecznosc);
            sb.AppendFormat("Wartość Ataku: {0} ", this.MocAtaku());
            return sb.ToString();
        }
    }

    public class Mag : Hero
    {
        public int PunktyMagii { get; set; }

        public Mag()
        {
            this.Imie = "Xardas";
            this.PktZycia = 1000;
            this.PktZyciaAktualnie = this.PktZycia;
            this.Sila = new Random().Next(1, 6);
            this.PunktyMagii = new Random().Next(2, 12);
            this.Zrecznosc = new Random().Next(2, 12);
        }

        public override decimal MocAtaku()
        {
            return (this.PunktyMagii + this.Sila) * this.PktZyciaAktualnie;
        }
    }

    public class Wojownik : Hero
    {
        public Wojownik()
        {
            this.Imie = "Geralt";

      this.PktZycia= 2000;
      this.PktZyciaAktualnie = this.PktZycia;
            this.Sila = new Random().Next(3, 18);
            this.Zrecznosc = new Random().Next(2, 12);
        }

        public override decimal MocAtaku()
        {
            if (this.PktZyciaAktualnie < 5 && this.PktZyciaAktualnie> 0)
                return Sila * 100;
            return Sila * this.PktZyciaAktualnie;
        }
    }

    public class Przedmiot
    {
        string nazwa;
        int cena;
        int waga;
        int moc;

        enum Kategoria{
            Bron,
            BronMagiczna,
            MiksturaLecznicza,
            Tarcza,
            Pieniadz
        };
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

            Console.WriteLine(" ");
            druzynaPierscienia[3] = e;
            Console.WriteLine(druzynaPierscienia[3].ToString());

            druzynaPierscienia[3] = e;
            e.ZmienZywotnosc(-364);
            e.ZmienZywotnosc(-364);
            e.ZmienZywotnosc(-361);

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
