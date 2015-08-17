﻿using System;

namespace ModelingObjectTask
{
    public class Mag : Hero
    {
        public int PunktyMagii { get; set; }

        public Mag()
        {
            this.Name = "Xardas";
            this.HealthPoints = 1000;
            this.Strength = new Random().Next(1, 6);
            this.PunktyMagii = new Random().Next(2, 12);
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
            return (this.PunktyMagii + this.Strength) * new Random().Next(2, 12);
        }

    }

}
