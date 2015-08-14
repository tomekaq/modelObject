using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingObjectTask
{
    class Druzyna : ICloneable
    {
        public string Nazwa { get; set; }
        List<Hero> druzynaPostaci = new List<Hero>();

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public object KopiaBohatera(int index)
        {
            var t = druzynaPostaci[index].Clone();

            return t;
        }

        public void DodajPostac(Hero hero)
        {
            druzynaPostaci.Add(hero);
        }

        public Hero this[int index]
        {
            get
            {
                return druzynaPostaci[index];
            }
            set
            {
                druzynaPostaci[index] = value;
            }
        }

        public decimal AtakDruzyny()
        {
            return druzynaPostaci.Select(x => x.MocAtaku()).Sum();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Nazwa: {0} ", Nazwa);
            sb.AppendFormat("Wartość ataku drużyny: {0} ", AtakDruzyny());
            sb.AppendFormat("Lista postaci: \n");
            druzynaPostaci.Select(x => sb.AppendFormat("{0} \n", x)).ToList();

            return sb.ToString();
        }
    }
}
