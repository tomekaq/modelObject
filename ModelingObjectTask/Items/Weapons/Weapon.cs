
namespace ModelingObjectTask.Items
{
    public class Weapon : Weapons
    {
        public override int Attack { get; set; }
        public override int Defense { get; set; }

        public Weapon()
        {
            Attack = 1;
            Defense = 1;
        }
    }
}
