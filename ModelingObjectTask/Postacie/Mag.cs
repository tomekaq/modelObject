using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingObjectTask
{
    public class Mag : Hero
    {
       // [DefaultValue("Geralt")]
        public override string Imie { get; set; }
        public int PunktyMagii { get; set; }

        public Mag()
        {
            Imie = "Xardas";
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

}
