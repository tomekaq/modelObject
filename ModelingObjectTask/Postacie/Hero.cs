using ModelingObjectTask.BodyParts;
using ModelingObjectTask.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelingObjectTask
{
    public abstract class Hero : ICloneable
    {
        protected string name;
        protected int strength;
        protected int agility;
        protected int healthPoints;
        protected int healthPointsNow;
        protected int moneyAmount;

        public abstract string Name { get; set; }
        public abstract int Strength { get; set; }
        public decimal Zywotnosc { get; set; }


        public Head glowa { get; set; }
        public LeftHand lewaReka { get; set; }
        public RightHand prawaReka { get; set; }
        public Legs nogi { get; set; }

        public List<Item> equipment = new List<Item>();

        public Hero()
        {
            HealthPoints = 200;
            Agility =  new Random().Next(2, 12);
            glowa = new Head();
            lewaReka = new LeftHand();
            lewaReka.Weapon.Atak = 1;
            prawaReka = new RightHand(200);
            nogi = new Legs();
        }

        public int MoneyAmount
        {
            get
            {
                return moneyAmount;
            }
            set
            {
                moneyAmount = value;
            }
        }

        public int HealthPoints
        {
            get
            {
                return healthPoints;
            }
            set
            {
                healthPoints = value;
                HealthPointsNow = value;
            }
        }

        public int HealthPointsNow
        {
            get
            {
                return healthPointsNow;
            }
            set
            {
                healthPointsNow = value;
            }
        }

        public int Agility //zrecznosc
        {
            get
            {
                return agility;
            }
            set
            {
                agility = value;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public abstract decimal AttackValue();

        public void AddItem(Item item)
        {
            equipment.Add(item);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Imię: {0} ", this.Name);
            sb.AppendFormat("Żywotność: {0:f}% ", (decimal)this.HealthPointsNow / this.HealthPoints * 100);
            sb.AppendFormat("Zręczność: {0} ", this.Agility);
            sb.AppendFormat("Wartość Ataku: {0} ", this.AttackValue());
            return sb.ToString();
        }

        public void ChangeHealth(int strata)
        {
            if (HealthPointsNow + strata < 0)
                HealthPointsNow = 0;
            else if ((this.HealthPointsNow + strata) - this.HealthPoints > 100)
                this.HealthPointsNow = this.HealthPoints;
            else
                this.HealthPointsNow += strata;
        }

    }

}
