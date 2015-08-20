
namespace ModelingObjectTask.Items
{
    public class MagicWeapon : Item
    {
        public int Attack { get; set; }
        public int Defense { get; set; }

        public MagicWeapon()
        {
            Attack = 1;
            Defense = 1;
        }
    }
}
