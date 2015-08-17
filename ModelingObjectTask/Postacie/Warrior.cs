using System;

namespace ModelingObjectTask
{
    public class Warrior : Hero
    {
        public Warrior()
        {
            this.Name = "Geralt";
            this.HealthPoints = 200;
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


        public override decimal AttackValue()
        {


            return (Strength + lewaReka.Weapon.Atak)* new Random().Next(2, 12);
        }
    }
}
