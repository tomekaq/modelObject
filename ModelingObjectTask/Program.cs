using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingObjectTask
{
    class Hero
    {
        internal abstract string _imie;
        internal abstract int _sila;
        internal abstract double _zywotnosc;
        
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
            sb.AppendFormat("Imię {0} ",_imie);
            sb.AppendFormat("Żywotność {0} ",_zywotnosc);
            sb.AppendFormat("Wartość Ataku {0} ",mocAtaku());
            return sb.ToString();
        }
    }

    class Mag:Hero
    {
        int _pktMagii;
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

    class Wojownik:Hero
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
        public double mocAtaku()
        {
            if (_zywotnosc < 5)
                return _sila; 
            return _sila * _zywotnosc;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
