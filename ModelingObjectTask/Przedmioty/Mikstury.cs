﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingObjectTask.Przedmioty
{
    class Mikstury:Przedmiot
    {
        public override string Nazwa{ get; set; }
        public override int Cena { get; set; }
        public override int Waga { get; set; }
    }
}
