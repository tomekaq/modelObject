
namespace ModelingObjectTask.Items
{
    public class Weapon : Item
    {
        public int Attack { get; private set; }
        public int Defense { get; private set; }

        public Weapon()
        {
            Attack = 1;
            Defense = 1;
        }
    }
}
