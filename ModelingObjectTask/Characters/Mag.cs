using ModelingObjectTask.Items;
using System;
using System.Linq;

namespace ModelingObjectTask
{
    public class Mag : Hero
    {
        public int Mana { get; set; }

        public Mag()
        {
            Name = "Xardas";
            Strength = new Random().Next(1, 6);
            Mana = new Random().Next(2, 12);
        }

        public override string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public override int Strength
        {
            get
            {
                return strength;
            }
            set
            {
                strength = value;
            }
        }

        public override int AttackValue()
        {
            var sumAttack = bodyPart
                    .Where(x => x.Alive == true)
                    .Where(x => x.Items.GetType() == typeof(MagicWeapon))
                    .Sum(x => x.Items.Cast<MagicWeapon>().Select(c => c.Attack).Sum());
            return (Mana + Strength + sumAttack) * Agility * new Random().Next(1, 6);
        }

    }

}
