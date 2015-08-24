using ModelingObjectTask.BodyParts;
using ModelingObjectTask.Items;
using System;
using System.Linq;

namespace ModelingObjectTask
{
    public class Mag : Hero
    {
        public int Mana { get; set; }
        DiceProvider dice = new DiceProvider();
        
        public Mag()
        {
            Name = "Xardas";
            Strength = dice.Throw(1, 6);
            Mana = dice.Throw(2, 12);
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
            return (Mana + Strength + sumAttack) * Agility;// *dice.Throw(1, 6);
        }

    }

}
