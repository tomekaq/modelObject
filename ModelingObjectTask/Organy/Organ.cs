using ModelingObjectTask.Przedmioty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingObjectTask.Organy
{
    public class Organ
    {

        protected int zdrowie;
        protected bool _jestWyposazona;
        protected Przedmiot przedmiot;
        protected Bron bron;

        public int Zdrowie
        {
            get
            {
                return zdrowie;
            }
            set
            {
                zdrowie = value;
            }
        }

        public bool JestWyposazona
        {
            get
            {
                return _jestWyposazona;
            }
            set
            {
                _jestWyposazona = value;
            }
        }

        public Przedmiot Przedmiot
        {
            get
            {
                return przedmiot;
            }
            set
            {
                przedmiot = value;
            }
        }

        public Bron Bron
        {
            get
            {
                return bron;
            }
            set
            {
                bron = value;
            }
        }

        public void Wyposaż(Przedmiot przedmiot)
        {
            this.JestWyposazona = true;
            if (przedmiot.GetType() == typeof(Bron))
            {
                bron = (Bron) przedmiot;
            }
            Przedmiot = przedmiot;
        }

    }
}

