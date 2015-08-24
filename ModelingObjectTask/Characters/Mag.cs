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

        public override int AttackValue()
        {
            var sumAttack = bodyPart
                .Where(x => x.Alive == true)
                .Where(x => x is LeftHand || x is RightHand)
                .Select(x=> x.Items
                    .Cast<MagicWeapon>()
                    .Sum(c=> c.Attack) ).FirstOrDefault();
            return (Mana + Strength + sumAttack) * Agility *DiceProvider.Instance.Throw(1, 6);
        }

    }

}
