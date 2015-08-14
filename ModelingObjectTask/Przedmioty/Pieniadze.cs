using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingObjectTask.Przedmioty
{
    public class Pieniadze : Przedmiot
    {
        public override string Nazwa { get; set; }
        public override int Cena { 
            get{return Cena;} 
            set{ Cena = 1;} 
        }
        public override int Waga { get; set; }
    }
}
