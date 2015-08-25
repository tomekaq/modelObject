﻿using ModelingObjectTask.BodyParts;
using ModelingObjectTask.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelingObjectTask
{
    public abstract class Hero
    {
        protected string name;
        protected int agility;
        protected int capacity;
        protected int defensePoint;
        protected int healthPoints;
        protected int healthPointsNow;
        protected int moneyAmount;
        protected int strength;

        public abstract string Name { get; set; }
        public abstract int Strength { get; set; }

        public Body body { get; set; }
        public Head head { get; set; }
        public LeftHand leftHand { get; set; }
        public RightHand rightHand { get; set; }
        public Legs legs { get; set; }

        protected List<BodyPart> bodyPart = new List<BodyPart>();
        protected List<Item> equipment = new List<Item>();

        public Hero()
        {
            IsAlive = true;
            Agility = DiceProvider.Instance.Throw(1, 12);
            DefensePoint = DiceProvider.Instance.Throw(3, 18);
            HealthPoints = 2000;
            HealthPointsNow = 2000;

            body = new Body();
            head = new Head();
            leftHand = new LeftHand();
            rightHand = new RightHand();
            legs = new Legs();
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

        public void AddItem(Item item)
        {
            if (item.Weight <= capacity)
            {
                equipment.Add(item);
                capacity -= item.Weight;
            }
        }

        public virtual int AttackValue<T>() where T : Weapons
        {

            var sumAttack = bodyPart
                 .Where(x => x.Alive)
                 .Where(x => x is LeftHand || x is RightHand)
                 .Sum(x => x.Items.Where(c => c is T)
                            .Cast<Weapons>()
                            .Sum(c => c.Attack));
            
            return sumAttack;
        
        }

        public void ChangeHealth(int strata)
        {
            if (HealthPointsNow + strata <= 0)
            {
                HealthPointsNow = 0;
                IsAlive = false;
            }
            if (!legs.Alive) { 
                Agility = 1;
            }

            if (!body.Alive || !head.Alive)
                IsAlive = false;
            else if ((this.HealthPointsNow + strata) - this.HealthPoints > 100)
                this.HealthPointsNow = this.HealthPoints;
            else
            {
                bodyPart.Select(x => x.Health += strata);
                this.HealthPointsNow += strata;
            }
        }

        public int DefenseValue()
        {
            var sumDefense = bodyPart
                        .Where(x => x.Alive)
                        .Sum(x =>
                        {
                            var sum = x.Clothes.Select(c => c.Defense).Sum();
                            return sum;
                        });
            return (DefensePoint + sumDefense) + Agility +DiceProvider.Instance.Throw(1, 6);
        }

        public decimal DrawAttack()
        {
            return (decimal)1 / new Random().Next(1, 6);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Imię: {0} ", Name);
            sb.AppendFormat("Żywotność: {0:f}% ", (decimal) HealthPointsNow / HealthPoints * 100);
            sb.AppendFormat("Zręczność: {0} ", Agility);
          //  sb.AppendFormat("Wartość Ataku: {0} ", AttackValue<T>());
            return sb.ToString();
        }
    }
}
