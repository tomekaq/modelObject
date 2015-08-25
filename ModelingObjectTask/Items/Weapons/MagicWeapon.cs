
namespace ModelingObjectTask.Items
{
    public class MagicWeapon : Weapons
    {
        public override int Attack { get; set; }
        public override int Defense { get; set; }

        public MagicWeapon()
        {
            Attack = 1;
            Defense = 1;
        }
    }
}
