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
            this.HealthPoints = 1000;
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
            if (leftHand.Item != null  && leftHand.Item.GetType() == typeof(MagicWeapon))
                return (Strength + Mana  ) * Agility * new Random().Next(2, 12);
            if (rightHand.Item != null && rightHand.Item.GetType() == typeof(MagicWeapon))
                return (Strength + Mana) * Agility * new Random().Next(2, 12);
            return (this.Mana + this.Strength) * Agility * new Random().Next(2, 12);
        }

    }

}
