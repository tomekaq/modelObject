
using ModelingObjectTask.BodyParts;
using ModelingObjectTask.Items;
using System;
using System.Linq;

namespace ModelingObjectTask
{
    public class Warrior : Hero
    {
        DiceProvider dice = new DiceProvider();

        public Warrior()
        {
            Name = "Geralt";
            Strength = dice.Throw(3, 18);
            Agility = dice.Throw(2, 12);
            HealthPointsNow = HealthPoints;
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
                .Select(x => x.Items
                    .Cast<MagicWeapon>()
                    .Sum(c => c.Attack)).FirstOrDefault();

            return (Strength + sumAttack) * Agility;// *dice.Throw(1, 6);
        }
    }
}
