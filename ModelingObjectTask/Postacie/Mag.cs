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
            PktZycia = 1000;
           PktZyciaAktualnie = PktZycia;
            Sila = new Random().Next(1, 6);
           PunktyMagii = new Random().Next(2, 12);
            Zrecznosc = new Random().Next(2, 12);
        }

        public override decimal MocAtaku()
        {
            return (this.PunktyMagii + this.Sila) * this.PktZyciaAktualnie;
        }

    }

}
