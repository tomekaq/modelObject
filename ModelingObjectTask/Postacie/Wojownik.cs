﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingObjectTask
{
    public class Wojownik : Hero
    {
       // [DefaultValue("Geralt")]
        public override string Imie { get; set; }
        public Wojownik()
        {

            this.PktZycia = 2000;
            this.PktZyciaAktualnie = this.PktZycia;
            this.Sila = new Random().Next(3, 18);
            this.Zrecznosc = new Random().Next(2, 12);
        }

        public override decimal MocAtaku()
        {
            var zyw = (decimal) PktZyciaAktualnie / PktZycia * 100;
            if (zyw < 5 && zyw > 0)
                return Sila * 100;
            return Sila * this.PktZyciaAktualnie;
        }
    }
}
