
using ModelingObjectTask.Items;
using System;
using System.Linq;

namespace ModelingObjectTask
{
    public class Warrior : Hero
    {
        public Warrior()
        {
            Name = "Geralt";
            Strength = new Random().Next(3, 18);
            Agility = new Random().Next(2, 12);
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
                     .Where(x => x.Items.GetType() == typeof(Weapon))
                     .Sum(x => x.Items.Cast<Weapon>().Select(c => c.Attack).Sum());

            return (Strength +sumAttack) * Agility * new Random().Next(1, 6);
        }
    }
}
