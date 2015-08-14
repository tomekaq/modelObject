using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingObjectTask.Przedmioty
{
    public abstract class Przedmiot
    {
        string Nazwa { get; set; }
        int Cena { get; set; }
        int waga { get; set; }
        int moc;

    }
    public class Bron : Przedmiot
    {
        // public override string Nazwa{get; set;}
    }

    public class BronMagiczna :Przedmiot
    {
        // public override string Nazwa{get; set;}
    }


}
