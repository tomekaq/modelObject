using ModelingObjectTask.BodyParts;
using ModelingObjectTask.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelingObjectTask
{
    public abstract class Hero : ICloneable
    {
        protected string name;
        protected bool isAlive;
        protected int agility;
        protected int capacity;
        protected int defensePoint;
        protected int healthPoints;
        protected int healthPointsNow;
        protected int moneyAmount;
        protected int strength;

        public abstract string Name { get; set; }
        public abstract int Strength { get; set; }

        public Head head { get; set; }
        public LeftHand leftHand { get; set; }
        public RightHand rightHand { get; set; }
        public Legs legs { get; set; }

        public List<Item> equipment = new List<Item>();

        public Hero()
        {
            isAlive = true;
            HealthPoints = 200;
            Agility = new Random().Next(2, 12);
            DefensePoint = new Random().Next(3, 18);
            head = new Head();
            leftHand = new LeftHand();
            leftHand.Weapon.Attack = 1;
            rightHand = new RightHand(200);
            legs = new Legs();
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

        public int DefensePoint
        {
            get
            {
                return defensePoint;
            }
            set
            {
                defensePoint = value;
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
        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
            set
            {
                isAlive = value;
            }
        }

        public int MoneyAmount
        {
            get
            {
                moneyAmount = equipment.Where(x => x.GetType() == typeof(Money)).Sum(x => x.Price);
                return moneyAmount;
            }
            set
            {
                moneyAmount = value;
                //var result = equipment.ForEach(x=>x);
                   ;
            }
        }

        public void AddItem(Item item)
        {
            equipment.Add(item);
        }

        public bool Attack(Hero hero)
        {
            if (hero.isAlive)
            {
                var offenserValue = this.Agility + new Random().Next(2, 12);
                var defenserValue = hero.Agility + new Random().Next(2, 12);
                if (offenserValue - defensePoint > 0)
                {
                    var attack = this.AttackValue();
                    hero.ChangeHealth(attack);
                    return true;
                }
                else
                {
                    var offenserValue2 = hero.Agility + new Random().Next(2, 12);
                    var defenserValue2 = this.Agility + new Random().Next(1, 6);
                    if (offenserValue - defensePoint > 0)
                    {
                        var attack = hero.AttackValue();
                        this.ChangeHealth(attack);
                        return true;
                    }
                    return false;
                }
            }
            else
                return false;
        }

        public void ChangeHealth(int strata)
        {
            if (HealthPointsNow + strata < 1)
            {
                HealthPointsNow = 0;
                IsAlive = false;
            }
            else if ((this.HealthPointsNow + strata) - this.HealthPoints > 100)
                this.HealthPointsNow = this.HealthPoints;
            else
                this.HealthPointsNow += strata;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public abstract int AttackValue();

        public int DefenseValue()
        {
            return DefensePoint;
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
    }
}
