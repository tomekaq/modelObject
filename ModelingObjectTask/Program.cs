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
        internal double _zywotnosc;

        public double OdejmijZywotnosc(double strata)
        {
            if (_zywotnosc - strata > 0 && _zywotnosc + strata < 100)
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
        public Mag(string imie, double zywotnosc, int sila, int pktMagii)
        {
            _imie = imie;
            _zywotnosc = zywotnosc;
            _sila = sila;
            _pktMagii = pktMagii;
        }
        public override double mocAtaku()
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
        public Wojownik(string imie, double zywotnosc, int sila)
        {
            _imie = imie;
            _zywotnosc = zywotnosc;
            _sila = sila;
        }
        public override double mocAtaku()
        {
            if (_zywotnosc < 5)
                return _sila;
            return _sila * _zywotnosc;
        }
    }

    class Druzyna //: ICloneable
    {
        string _nazwa;
        List<Hero> druzynaPostaci = new List<Hero>();

        public Druzyna(string nazwa)
        {
            _nazwa = nazwa;
        }
        //object ICloneable.Clone()
        //{
        //    return this.Clone();
        //}

        //public Hero Clone()
        //{
        //    return (Hero)this.MemberwiseClone();
        //}

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
            sb.AppendFormat("Żywotność: {0} ", AtakDruzyny());
            

            
            sb.AppendFormat("Lista postaci:  ");
            var fgf =sb.AppendFormat("{0}", druzynaPostaci.Select(x => x.ToString()).ToList());
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

            c.OdejmijZywotnosc(-30);
            Console.WriteLine(
            c.ToString());

            var druzynaPierscienia = new Druzyna("druzyna Pierscienia");
            druzynaPierscienia.DodajPostac(a);

            var gg = druzynaPierscienia[0];
            Console.WriteLine("Pobranie z listy {0}", gg);

            var sklonowanyGerald = druzynaPierscienia[0];//.Clone();
           // var bbb = druzynaPierscienia.Clone();

            druzynaPierscienia.DodajPostac(sklonowanyGerald);
            Console.WriteLine("Wartosc ataku druzyny: {0}", druzynaPierscienia.AtakDruzyny());


            Console.WriteLine(" ");
            Console.WriteLine("{0}", druzynaPierscienia.ToString());



            var g = b._imie;

            var pk = b.OdejmijZywotnosc(-3);

            Console.ReadLine();

        }
    }
}
