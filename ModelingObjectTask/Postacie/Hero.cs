using ModelingObjectTask.Organy;
using ModelingObjectTask.Przedmioty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingObjectTask
{
    public abstract class Hero : ICloneable
    {
        public abstract string Imie { get; set; }
        public int Sila { get; set; }
        public decimal Zywotnosc { get; set; }
        public int PktZycia { get; set; }
        public int PktZyciaAktualnie { get; set; }
        public int Zrecznosc { get; set; }
        public List<Przedmiot> ekwipunek = new List<Przedmiot>();

        public int IloscPieniedzy { get; set; }

        public Glowa glowa { get; set; }
        public LewaReka lewaReka { get; set; }
        public PrawaReka prawaReka { get; set; }
        public Nogi nogi { get; set; }


        public Hero() {

            glowa = new Glowa();
            lewaReka = new LewaReka();
            prawaReka = new PrawaReka();
            nogi = new Nogi();
        
        }

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

        public void DodajPrzedmiot(Przedmiot przedmiot)
        {
            ekwipunek.Add(przedmiot);
        }

        public bool UbierzPrzedmiot(Przedmiot przedmiot, Organ organ)
        {
            if (!organ.JestWyposazona)
            {
                organ.JestWyposazona = true;
                organ.Przedmiot = przedmiot;
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Imię: {0} ", this.Imie);
            sb.AppendFormat("Żywotność: {0:f}% ", (decimal)this.PktZyciaAktualnie / this.PktZycia * 100);
            sb.AppendFormat("Zręczność: {0} ", this.Zrecznosc);
            sb.AppendFormat("Wartość Ataku: {0} ", this.MocAtaku());
            return sb.ToString();
        }
    }

}
