
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

        public int AttackValue()
        {
            var sum = base.AttackValue<Weapon>();

            return (Strength + sum) + Agility +DiceProvider.Instance.Throw(1, 6);
        }
    }
}
