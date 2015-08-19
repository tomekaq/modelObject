
namespace ModelingObjectTask.Items
{
    public class MagicWeapon : Item
    {
        public int Attack { get { return this.Attack; } set { this.Attack = (value > 0 ? value : 0); } }
        public int Defense { get { return this.Defense; } set { this.Defense = (value > 0 ? value : 0); } }

        public MagicWeapon()
        {
            Attack = 1;
            Defense = 1;
        }
    }
}
