
using ModelingObjectTask.Items;
using System;
using System.Linq;

namespace ModelingObjectTask
{
    public class Warrior : Hero
    {
        public Warrior()
        {
            this.Name = "Geralt";
            this.Strength = new Random().Next(3, 18);
            this.Agility = new Random().Next(2, 12);
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
            var sumAttack = 0;
            if (leftHand.Item != null && leftHand.Item.GetType()== typeof(Weapon))
            {
                var weapon = (Weapon)leftHand.Item;;
                sumAttack += weapon.Attack;
            }
            if (rightHand.Item != null && rightHand.Item.GetType() == typeof(Weapon))
            {
                var weapon = (Weapon)rightHand.Item; ;
                sumAttack += weapon.Attack;
            }
            return (Strength +sumAttack) * Agility * new Random().Next(2, 12);
        }
    }
}
