using ModelingObjectTask.Items;
using System;

namespace ModelingObjectTask
{
    public class Mag : Hero
    {
        public int Mana { get; set; }

        public Mag()
        {
            this.Name = "Xardas";
            this.Strength = new Random().Next(1, 6);
            this.Mana = new Random().Next(2, 12);
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
            if (leftHand.Item != null && leftHand.Item.GetType() == typeof(MagicWeapon))
            {
                var weapon = (MagicWeapon)leftHand.Item;
                sumAttack += weapon.Attack;
            }
            if (rightHand.Item != null && rightHand.Item.GetType() == typeof(MagicWeapon))
            {
                var weapon = (MagicWeapon)rightHand.Item;
                sumAttack += weapon.Attack;
            }
            return (Mana + Strength + sumAttack) * Agility * new Random().Next(2, 12);
        }

    }

}
