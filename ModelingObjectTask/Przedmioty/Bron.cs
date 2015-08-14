using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingObjectTask.Przedmioty
{
    public class Bron : Przedmiot
    {
       public override string Nazwa{get; set;}
       public int Sila { get; set; }        public override int Cena { get; set; }
       public override int Waga { get; set; }
    }
}
