using ModelingObjectTask.BodyParts;
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
            Strength = DiceProvider.Instance.Throw(1, 6);
            Mana = DiceProvider.Instance.Throw(2, 12);
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

        public int AttackValue()
        {
            var sum = base.AttackValue<MagicWeapon>();
                              
            return (Mana + Strength+ sum ) + Agility + DiceProvider.Instance.Throw(1, 6);
        }
    }
}
