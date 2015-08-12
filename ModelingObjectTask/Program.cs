using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingObjectTask
{
    abstract class Hero
    {
        internal string _imie;
        internal int _sila;
        internal decimal _zywotnosc;

        public decimal zmienZywotnosc(decimal strata)
        {
            if (_zywotnosc - strata > 0)
                return 0;
            if (_zywotnosc + strata < 100)
                return 100;
                _zywotnosc += strata;
            return _zywotnosc;

        }
        public abstract double mocAtaku();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Imię: {0} ", _imie);
            sb.AppendFormat("Żywotność: {0} ", _zywotnosc);
            sb.AppendFormat("Wartość Ataku: {0} ", mocAtaku());
            return sb.ToString();
        }

    }

    class Mag : Hero
    {
        private int _pktMagii;

        public Mag()
        {
            _imie = "Xardas";
            _zywotnosc = 100;
            Random rnd = new Random();
            _sila = rnd.Next(1, 6);
            _pktMagii = rnd.Next(2, 12);
        }
        public Mag(string imie, decimal zywotnosc, int sila, int pktMagii)
        {
            _imie = imie;
            _zywotnosc = zywotnosc;
            _sila = sila;
            _pktMagii = pktMagii;
        }
        public override decimal mocAtaku()
        {
            return (_pktMagii + _sila) * _zywotnosc;
        }

    }

    class Wojownik : Hero
    {
        public Wojownik()
        {
            _imie = "Geralt";
            _zywotnosc = 100;
            Random rnd = new Random();
            _sila = rnd.Next(3, 18);
        }
        public Wojownik(string imie, decimal zywotnosc, int sila)
        {
            _imie = imie;
            _zywotnosc = zywotnosc;
            _sila = sila;
        }
        public override decimal mocAtaku()
        {
            if (_zywotnosc < 5)
                return _sila* 100;
            return _sila * _zywotnosc;
        }
    }

    class Druzyna : ICloneable
    {
        string _nazwa;
        List<Hero> druzynaPostaci = new List<Hero>();

        public Druzyna(string nazwa)
        {
            _nazwa = nazwa;
        }
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

        public double AtakDruzyny()
        {
            return druzynaPostaci.Select(x => x.mocAtaku()).Sum();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Nazwa: {0} ", _nazwa);
            sb.AppendFormat("Wartość ataku drużyny: {0} ", AtakDruzyny());
            
            
            sb.AppendFormat("Lista postaci: \n");
            druzynaPostaci.Select(x => x.ToString()).Select(x => sb.AppendFormat("{0}  \n", x)).ToList();
            Console.WriteLine();
            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new Wojownik();
            Console.WriteLine(
            a.ToString());

            var b = new Mag();
            Console.WriteLine(
            b.ToString());

            var c = new Mag("Nowy", 100, 30, 40);
            Console.WriteLine(
            c.ToString());

            var d = new Wojownik();
            d.zmienZywotnosc(-96);
            Console.WriteLine(
            d.ToString());

            var druzynaPierscienia = new Druzyna("Druzyna pierścienia");
            druzynaPierscienia.DodajPostac(a);
            druzynaPierscienia.DodajPostac(b);
            druzynaPierscienia.DodajPostac(c);
            druzynaPierscienia.DodajPostac(d);

            Console.WriteLine(druzynaPierscienia[2].ToString());

            var e = new Wojownik("e",34,5);
            druzynaPierscienia[3] = e;
            Console.WriteLine(druzynaPierscienia[3].ToString());


            var pk = b.zmienZywotnosc(-3);

            Console.WriteLine(druzynaPierscienia.ToString());

            var nowaDruzyna = druzynaPierscienia.Clone();



            Console.WriteLine("Nowa");
            Console.WriteLine(nowaDruzyna.ToString());

            Console.ReadLine();

        }
    }
}
