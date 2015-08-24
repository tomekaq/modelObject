using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelingObjectTask
{
    class Squad : ICloneable
    {
        public string Name { get; set; }
        List<Hero> druzynaPostaci = new List<Hero>();

        public object Clone()
        {
            return this.MemberwiseClone();
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
            return druzynaPostaci.Select(x => x.AttackValue()).Sum();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Nazwa: {0} ", Name);
            sb.AppendFormat("Wartość ataku drużyny: {0} ", AtakDruzyny());
            sb.AppendFormat("Lista postaci: \n");
            druzynaPostaci.Select(x => sb.AppendFormat("{0} \n", x)).ToList();

            return sb.ToString();
        }
    }
}
