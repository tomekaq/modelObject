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
        protected bool _jestWyposazona;
        protected Przedmiot przedmiot;
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
        public Przedmiot Przedmiot {
            get
            {
                return przedmiot;
            }
            set
            {
                przedmiot = value;
            }
        }

    }
}

