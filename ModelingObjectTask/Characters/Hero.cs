using ModelingObjectTask.BodyParts;
using ModelingObjectTask.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace ModelingObjectTask
{
    public abstract class Hero
    {
        protected string name;
        protected int agility;
        protected int capacity;
        protected int capacityNow;
        protected int defensePoint;
        protected int healthPoints;
        protected int healthPointsNow;
        protected int moneyAmount;
        protected int strength;

        public Body body;
        public Head head;
        public LeftHand leftHand;
        public RightHand rightHand;
        public Legs legs;

        public abstract string Name { get; set; }
        public abstract int Strength { get; set; }

        public List<BodyPart> bodyPart = new List<BodyPart>();
        public List<Item> equipment = new List<Item>();

        public Body Body
        {
            get
            {
                return body;
            }
            set
            {
                body = value;
            }
        }

        public Hero()
        {
            IsAlive = true;
            Agility = DiceProvider.Instance.Throw(1, 12);
            DefensePoint = DiceProvider.Instance.Throw(3, 18);
            HealthPoints = 1000;
            HealthPointsNow = 1000;

            body = new Body() { Health = 200 };
            head = new Head() { Health = 200 };
            leftHand = new LeftHand() { Health = 200 };
            rightHand = new RightHand() { Health = 200 };
            legs = new Legs() { Health = 200 };

            bodyPart.Add(body);
            bodyPart.Add(head);
            bodyPart.Add(leftHand);
            bodyPart.Add(rightHand);
            bodyPart.Add(legs);

        }

        public int Agility
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

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int CapacityNow
        {
            get { return capacityNow; }
            set { capacityNow = value; }
        }
        public int DefensePoint
        {
            get
            {
                return defensePoint;
            }
            set
            {
                defensePoint = (value > 0 ? value : 0);
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
                healthPoints = (value > 0 ? value : 0);
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
                healthPointsNow = (value > 0 ? value : 0);
                IsAlive = healthPointsNow > 0;
            }
        }

        public bool IsAlive
        {
            get;
            private set;
        }

        public int MoneyAmount
        {
            get
            {
                moneyAmount = equipment
                            .Where(x => x is Money)
                            .Sum(x => x.Price);
                return moneyAmount;
            }
            set
            {
                moneyAmount = value;
            }
        }

        public virtual void AddItem(Item item)
        {
            if (item.Weight <= capacity)
            {
                equipment.Add(item);
                capacity -= item.Weight;
            }
        }

        public virtual void Attack(Hero enemy)
        {
            Attack(enemy, 1);
        }

        protected virtual void Attack(Hero enemy, int phase)
        {
            var myAttack = this.AttackValue();
            var enemyDefense = enemy.DefenseValue();
            var myHit = myAttack + DiceProvider.Instance.Throw(1, 12 / phase);
            var enemyHit = enemyDefense + DiceProvider.Instance.Throw(1, 12);
            if (myHit > enemyHit)
            {
                var HitPoints = (int)(myHit * DrawAttack());
                enemy.ChangeHealth(HitPoints);
            }
            else
            {
                if (phase < 2)
                    enemy.Attack(this, phase + 1);
            }
        }

        public virtual int AttackValue()
        {
            var sumAttack = bodyPart
                 .Where(x => x.Alive)
                 .Where(x => x is LeftHand || x is RightHand)
                 .Sum(x => x.Items.Where(c => c is Weapons)
                            .Cast<Weapons>()
                            .Sum(c => c.Attack));

            return sumAttack;
        }

        public void ChangeHealth(int AttackValue)
        {
            var health = HealthPointsNow - AttackValue;

            if (health <= 0)
            {
                HealthPointsNow = 0;
                IsAlive = false;
            }
            else if (health > HealthPoints)
                HealthPointsNow = HealthPoints;
            else
            {
                this.HealthPointsNow = health;
                this.bodyPart
                        .Select(x =>
                        {
                            x.ChangeHealth(AttackValue / DiceProvider.Instance.Throw(1, 6));
                            return x;
                        }).ToList();

                if (!this.legs.Alive)
                    Agility = 0;
                if (!this.body.Alive || !this.head.Alive)
                    IsAlive = false;
            }
        }

        public int DefenseValue()
        {
            var sumDefense1 = bodyPart
                        .Where(x => x.Alive);
            var sumDefense = sumDefense1.Sum(x =>
                        {
                            var sum = x.Clothes.Select(c => c.Defense).Sum();
                            return sum;
                        });
            return (DefensePoint + sumDefense) + Agility + DiceProvider.Instance.Throw(1, 6);
        }

        public decimal DrawAttack()
        {
            return (decimal)1 / DiceProvider.Instance.Throw(1, 6);
        }

        public void PutOnBodyPart(Item item, BodyPart part)
        {
            if (equipment.Contains(item))
                part.PutOn(item);
        }



        public string GetInfoBodyPart() 
        {
            StringBuilder sb = new StringBuilder();
            this.bodyPart.ForEach(x => sb.AppendFormat("{0} {1} {2} \n", x.GetType().Name, x.Alive, x.Health));
            return sb.ToString();
        }

        public string ShowEquipment()
        {
            StringBuilder sb = new StringBuilder();
            var tt = equipment.GroupBy(x => x.GetType().Name)
                              .OrderBy(x => x.GetType().Name);
            tt.ToList().Select(x => x.Select(y => sb.AppendFormat("{0} \n", y.ToString())).ToList()).ToList();
            //equipment.ForEach(x => sb.AppendFormat("{0} \n", x.ToString()));
            return sb.ToString();

            //return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Imię: {0} ", Name);
            sb.AppendFormat("Żywotność: {0:f}% ", (decimal)HealthPointsNow / HealthPoints * 100);
            sb.AppendFormat("Udźwig: {0}/{1} ", this.CapacityNow,this.Capacity);
            sb.AppendFormat("Punkty Obrony: {0} ", this.DefensePoint);
            sb.AppendFormat("Zręczność: {0} ", Agility);
            sb.AppendFormat("Pieniądze: {0} ", this.MoneyAmount);
            sb.AppendFormat("Siła: {0} ", this.Strength);

            return sb.ToString();
        }
    }
}
